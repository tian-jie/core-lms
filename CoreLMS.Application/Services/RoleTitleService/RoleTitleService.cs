using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;

namespace CoreLMS.Application.Services
{
    public class RoleTitleService : BaseService<RoleTitle>, IRoleTitleService
    {
        public RoleTitleService(IAppDbContext unitOfWork)
            : base(unitOfWork)
        {

        }

    }
}
