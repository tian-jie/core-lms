using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;
using CoreLMS.Core.ViewModels;
using CoreLMS.Persistence;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLMS.Application.Services.CourseLessonService
{
    public class ProjectCostService : IProjectCostService
    {
        private readonly IRepository<ProjectCost> _repository;
        private readonly ILogger<ProjectCostService> logger;

        public ProjectCostService(IRepository<ProjectCost> repository, ILogger<ProjectCostService> logger)
        {
            this._repository = repository;
            this.logger = logger;
        }


        public async Task<List<ProjectCost>> AccountCostByProject(int projectId)
        {
            return (await _repository.WhereAsync(r => r.ProjectId == projectId)).ToList();
        }

        public async Task<List<ProjectCostViewModel>> AccountAllProjectCost()
        {
            var projectCost = (await _repository.AllAsync()).GroupBy<ProjectCost, int>(r => r.ProjectId );
            var projectWithCosts = new List<ProjectCostViewModel>();

            foreach(var pc in projectCost)
            {
                projectWithCosts.Add(new ProjectCostViewModel()
                {
                    ProjectId = pc.Key,
                    ProjectName = pc.First().ProjectName,
                    TotalAmount = pc.Sum(r => r.TotalAmount)
                });
            }
            return projectWithCosts;

        }

    }
}
