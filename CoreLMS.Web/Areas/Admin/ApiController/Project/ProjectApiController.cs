using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;
using CoreLMS.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreLMS.Web.Areas.Admin.ApiController
{
    [Route("api/project")]
    [ApiController]
    public class ProjectApiController : ControllerBase
    {
        private IProjectCostService _projectCostService;
        private IProjectService _projectService;

        public ProjectApiController(IProjectCostService projectCostService, IProjectService projectService)
        {
            _projectCostService = projectCostService;
            _projectService = projectService;
        }


        /// <summary>
        /// 查询某个时间区间内的项目费用信息，仅到项目级别
        /// </summary>
        /// <param name="startMonth">查询区间开始时间</param>
        /// <param name="endMonth">查询区间结束时间</param>
        /// <param name="projectStatus">是否使用某个状态进行过滤，输入空则表示不过滤。这个字段包含：Not Started / Projection / Ongoing / On Hold / Completed / Canceled </param>
        /// <returns></returns>
        [HttpGet("get-all-project-cost")]
        public async Task<List<ProjectCostViewModel>> GetAllProjectCost(int startMonth, int endMonth, string projectStatus = "")
        {
            return await _projectCostService.AccountAllProjectCost(startMonth, endMonth, projectStatus);
        }


        /// <summary>
        /// 查询某个时间区间内的项目支出，精确到人，以及月
        /// </summary>
        /// <param name="startDate">查询区间开始时间</param>
        /// <param name="endDate">查询区间结束时间</param>
        /// <param name="projectStatus">是否使用某个状态进行过滤，输入空则表示不过滤。这个字段包含：Not Started / Projection / Ongoing / On Hold / Completed / Canceled </param>
        /// <returns></returns>
        [HttpGet("get-project-cost-detail")]
        public async Task<List<ProjectCost>> GetProjectCostDetail(int startMonth, int endMonth, string projectStatus = "")
        {
            return await _projectCostService.AccountProjectCostDetail(startMonth, endMonth, projectStatus);
        }

        /// <summary>
        /// 查询某个时间区间内的项目支出，精确到人，以及月，单个项目
        /// </summary>
        /// <param name="startDate">查询区间开始时间</param>
        /// <param name="endDate">查询区间结束时间</param>
        /// <param name="projectStatus">是否使用某个状态进行过滤，输入空则表示不过滤。这个字段包含：Not Started / Projection / Ongoing / On Hold / Completed / Canceled </param>
        /// <returns></returns>
        [HttpGet("get-project-cost-detail-by-project")]
        public async Task<List<ProjectCost>> GetProjectCostDetailByProject(int startMonth, int endMonth, int projectId)
        {
            var result = await _projectCostService.AccountCostByProject(startMonth, endMonth, projectId);
            var ss = from a in result
                     group a by new { a.ProjectId, a.ProjectName, a.EmployeeId, a.EmployeeName, a.EmployeeTitleId, a.EmployeeTitleName } into l2
                     select new ProjectCost()
                     {
                         ProjectId = l2.Key.ProjectId,
                         ProjectName = l2.Key.ProjectName,
                         EmployeeId = l2.Key.EmployeeId,
                         EmployeeName = l2.Key.EmployeeName,
                         EmployeeTitleId = l2.Key.EmployeeTitleId,
                         EmployeeTitleName = l2.Key.EmployeeTitleName,
                         TotalAmount = l2.Sum(x => x.TotalAmount),
                         TotalCost = l2.Sum(x => x.TotalCost)
                     };
            return ss.ToList();
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }




    }
}
