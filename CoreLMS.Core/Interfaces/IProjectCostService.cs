using CoreLMS.Core.Entities;
using CoreLMS.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLMS.Core.Interfaces
{
    public interface IProjectCostService
    {
        Task<List<ProjectCost>> AccountCostByProject(int projectId);

        Task<List<ProjectCostViewModel>> AccountAllProjectCost();
    }
}
