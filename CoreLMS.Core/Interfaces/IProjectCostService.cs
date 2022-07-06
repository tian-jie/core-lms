using CoreLMS.Core.Entities;
using CoreLMS.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLMS.Core.Interfaces
{
    public interface IProjectCostService
    {
        Task<List<ProjectCost>> AccountCostByProject(int startMonth, int endMonth, int projectId);

        Task<List<ProjectCostViewModel>> AccountAllProjectCost(int startMonth, int endMonth, string projectStatus = "");

        /// <summary>
        /// 查询某个时间区间内的项目支出，精确到人，以及月
        /// </summary>
        /// <param name="startDate">查询区间开始时间</param>
        /// <param name="endDate">查询区间结束时间</param>
        /// <param name="projectStatus">是否使用某个状态进行过滤，输入空则表示不过滤。这个字段包含：Not Started / Projection / Ongoing / On Hold / Completed / Canceled </param>
        /// <returns></returns>
        Task<List<ProjectCost>> AccountProjectCostDetail(int startMonth, int endMonth, string projectStatus = "");
    }
}
