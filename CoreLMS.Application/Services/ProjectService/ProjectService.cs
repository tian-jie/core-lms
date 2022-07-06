using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;

namespace CoreLMS.Application.Services
{
    public class ProjectService : BaseService<ProjectTask>, IProjectService
    {
        public ProjectService(IAppDbContext unitOfWork)
            : base(unitOfWork)
        {

        }



    }
}
