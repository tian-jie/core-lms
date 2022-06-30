using Kevin.T.Clockify.Data.Entities;
using Kevin.T.Clockify.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLMS.Core.Interfaces
{
    public interface IClockifyService
    {
        Task<LoginModel> Login(string username, string password);

        Task<string> GetWorkspaceId(string userId, string token);

        Task<List<UserModel>> GetUsers(string userid, string token);

        Task<List<TimeEntryModel>> GetTimeEntries(string userid, string token, string startDate, string endDate);

        Task UpdateTimeEntriesToDatabase(int startDate, int endDate, List<TimeEntryModel> timeEntriesInClockify);
    }
}
