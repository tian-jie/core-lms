using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;
using CoreLMS.Core.ViewModels;
using CoreLMS.Persistence;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLMS.Application.Services
{
    public class ProjectCostService : BaseService<ProjectCost>, IProjectCostService
    {
        public ProjectCostService(IAppDbContext unitOfWork)
            : base(unitOfWork)
        {

        }


        public async Task<List<ProjectCost>> AccountCostByProject(int startMonth, int endMonth, int projectId)
        {
            return (await _repository.WhereAsync(r => r.ProjectId == projectId && r.YearMonth >= startMonth && r.YearMonth <= endMonth)).ToList();
        }

        public async Task<List<ProjectCost>> AccountProjectCostDetail(int startMonth, int endMonth, string projectStatus = "")
        {
            var list = await _repository.WhereAsync(a => a.YearMonth >= startMonth && a.YearMonth <= endMonth);
            if (!string.IsNullOrEmpty(projectStatus))
            {
                list = list.Where(a=>a.ProjectStatus == projectStatus);
            }
            return list.ToList();
        }

        public async Task<List<ProjectCostViewModel>> AccountAllProjectCost(int startMonth, int endMonth, string projectStatus = "")
        {
            var list = await _repository.WhereAsync(a => a.YearMonth >= startMonth && a.YearMonth <= endMonth);
            if (!string.IsNullOrEmpty(projectStatus))
            {
                list = list.Where(a=>a.ProjectStatus == projectStatus);
            }

            var list1 = from l in list group l by new { l.ProjectId, l.ProjectName } into l2
                        select new ProjectCostViewModel()
                        {
                            ProjectId = l2.Key.ProjectId,
                            ProjectName = l2.Key.ProjectName,
                            TotalAmount = l2.Sum(r => r.TotalAmount)
                        };

            var projectWithCosts = list1.ToList();
            return projectWithCosts;

        }

    }
}
