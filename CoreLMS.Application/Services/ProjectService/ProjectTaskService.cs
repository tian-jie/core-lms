using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;

namespace CoreLMS.Application.Services
{
    public class ProjectTaskService : BaseService<ProjectTask>, IProjectTaskService
    {
        public ProjectTaskService(IAppDbContext unitOfWork)
            : base(unitOfWork)
        {

        }



    }
}
