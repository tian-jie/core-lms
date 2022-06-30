using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using Kevin.T.Clockify.Data.Entities;
using Kevin.T.Clockify.Data.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoreLMS.Application.Services
{
    public class ClockifyService: IClockifyService
    {
        internal readonly ILog _logger = LogManager.GetLogger(typeof(ClockifyService));
        object timeentries_locker = new object();
        private readonly ITimeEntryService _timeEntryService;

        public ClockifyService(ITimeEntryService timeEntryService)
        {
            _timeEntryService = timeEntryService;
        }
        public async Task<LoginModel> Login(string username, string password)
        {
            string url = "https://global.api.clockify.me/auth/token";
            string loginBodyFormat = "{{\"email\":\"{0}\",\"password\":\"{1}\"}}";

            string loginBody = string.Format(loginBodyFormat, username, password);
            var content = new StringContent(loginBody, System.Text.Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Origin", "https://clockify.me");
            httpClient.DefaultRequestHeaders.Referrer = new System.Uri("https://clockify.me/login");
            //httpClient.DefaultRequestHeaders.Add(":authority", "global.api.clockify.me");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(url, content);


            var res = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Exception(res);
            }

            var resultModel = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginModel>(res);

            return resultModel;
        }

        public async Task<string> GetWorkspaceId(string userId, string token)
        {
            string url = string.Format("https://global.api.clockify.me/users/{0}/", userId);

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Origin", "https://clockify.me");
            httpClient.DefaultRequestHeaders.Add("x-auth-token", token);
            httpClient.DefaultRequestHeaders.Referrer = new System.Uri("https://clockify.me/login");
            //httpClient.DefaultRequestHeaders.Add(":authority", "global.api.clockify.me");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(url);


            var res = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Exception(res);
            }

            var resultModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMembershipModel>(res);

            return resultModel.defaultWorkspace;
        }

        public async Task<List<UserModel>> GetUsers(string userid, string token)
        {
            string url = string.Format("https://global.api.clockify.me/users/workspaces/{0}/members?sort-column=NAME&sort-order=ASCENDING&page=1&page-size=1000", userid);

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Origin", "https://clockify.me");
            httpClient.DefaultRequestHeaders.Add("x-auth-token", token);
            httpClient.DefaultRequestHeaders.Referrer = new System.Uri("https://clockify.me/");

            var response = await httpClient.GetAsync(url);

            var res = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Exception(res);
            }

            var resultModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserModel>>(res);

            return resultModel;
        }

        public async Task<List<TimeEntryModel>> GetTimeEntries(string userid, string token, string startDate, string endDate)
        {
            _logger.Debug("Starting to GetTimeEntries...");
            string url = string.Format("https://reports.api.clockify.me/workspaces/{0}/reports/detailed", userid);


            string bodyFormat = "{{\"dateRangeStart\":\"{0}T00:00:00.000Z\",\"dateRangeEnd\":\"{1}T23:59:59.999Z\",\"sortOrder\":\"DESCENDING\",\"description\":\"\",\"rounding\":false,\"withoutDescription\":false,\"amounts\":null,\"amountShown\":\"HIDE_AMOUNT\",\"zoomLevel\":\"MONTH\",\"userLocale\":\"zh_CN\",\"customFields\":null,\"detailedFilter\":{{\"sortColumn\":\"DATE\",\"page\":{2},\"pageSize\":1000,\"auditFilter\":null,\"quickbooksSelectType\":\"ALL\",\"options\":{{\"totals\":\"CALCULATE\"}}}}}}";
            var timeentries = new List<TimeEntryModel>();

            var totalPages = await GetTimeEntryByPage(token, startDate, endDate, url, bodyFormat, 0, timeentries, 1);

            //for(var i=2; i<=totalPages; i++)
            //{
            //    await GetTimeEntryByPage(token, startDate, endDate, url, bodyFormat, totalPages, timeentries, i);
            //}

            var tasks = new List<Task>();
            for (var i = 2; i <= totalPages; i++)
            {
                var task = GetTimeEntryByPage(token, startDate, endDate, url, bodyFormat, totalPages, timeentries, i);
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            return timeentries;
        }

        private async Task<int> GetTimeEntryByPage(string token, string startDate, string endDate, string url, string bodyFormat, int totalPages, List<TimeEntryModel> timeentries, int page)
        {
            _logger.Debug($"  - getting page {page}, total:{totalPages}");
            string body = string.Format(bodyFormat, startDate, endDate, page);

            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Origin", "https://app.clockify.me/");
            httpClient.DefaultRequestHeaders.Add("x-auth-token", token);
            httpClient.DefaultRequestHeaders.Referrer = new System.Uri("https://app.clockify.me/");

            httpClient.Timeout = new TimeSpan(0, 10, 0);

            var response = await httpClient.PostAsync(url, content);

            var res = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Exception(res);
            }
            //if (res.Contains("[]"))
            //{
            //    return timeentries;
            //}

            var resultModel = Newtonsoft.Json.JsonConvert.DeserializeObject<TimeEntryResponseModel>(res);
            if (resultModel.timeentries != null)
            {
                lock (timeentries_locker)
                {
                    timeentries.AddRange(resultModel.timeentries);
                }
            }

            if (resultModel.totals != null && resultModel.totals.Count >= 0)
            {
                var entriesCount = resultModel.totals[0].entriesCount;
                totalPages = entriesCount / 1000 + (entriesCount % 1000 > 0 ? 1 : 0);
            }

            _logger.Debug(string.Format("  - finished getting page {0}, total:{1}, record count: {2}", page, totalPages, resultModel.timeentries.Count));

            return totalPages;
        }

        public async Task UpdateTimeEntriesToDatabase(int startDate, int endDate, List<TimeEntryModel> timeEntriesInClockify)
        {
            _logger.Debug($"{DateTime.Now.ToString("u")}  - Writing timeentry data to database, total record count: {timeEntriesInClockify.Count}");
            await _timeEntryService.DeleteRangeAsync(a => a.Date >= startDate && a.Date <= endDate);

            // 写TimeEntry
            var timeEntries = new List<TimeEntry>();
            var count = 0;
            foreach (var tc in timeEntriesInClockify)
            {
                timeEntries.Add(new TimeEntry()
                {
                    Gid = tc._id,
                    IsBillable = tc.billable,
                    IsDeleted = false,
                    IsLocked = tc.isLocked,
                    ProjectId = tc.projectId,
                    Description = tc.description,
                    Date = int.Parse(DateTime.Parse(tc.timeInterval.start.Substring(0, 10)).ToString("yyyyMMdd")),
                    TaskId = tc.taskId,
                    TotalAmount = tc.timeInterval.duration,
                    CreatedUserID = "auto",
                    UpdatedUserID = "auto",
                    UserId = tc.userId
                });
                count++;
            }

            _logger.Debug($"{DateTime.Now.ToString("u")}  - Flushing data ({count})...");
            using (AppDbContext db = (AppDbContext)_timeEntryService.UnitOfWork)
            {
                await db.BulkInsertAsync(timeEntries);
                //db.TimeEntries.GetContext().BulkInsert(timeEntries);
                //await db.TimeEntries.AddRangeAsync(timeEntries);
                //await db.SaveChangesAsync();
            }
            _logger.Debug($"{DateTime.Now.ToString("u")}  - done on write timeentry to database. record count: {timeEntries.Count}");
            timeEntries.Clear();

            // TODO: 看有没有不存在的员工，需要添加进来
            var employees = (from tc in timeEntriesInClockify select new Employee() { Gid = tc.userId, Email = tc.userEmail, Name = tc.userName }).ToList();
            // TODO: 过滤掉已经有的employee

            // TODO: 看有没有不存在的项目，需要添加进来
            var projects = (from tc in timeEntriesInClockify select new Project() { Gid = tc.projectId, Name = tc.projectName }).ToList();
            // TODO: 过滤掉已经有的Project

        }


    }
}
