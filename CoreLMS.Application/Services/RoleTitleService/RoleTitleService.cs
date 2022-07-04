using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using Microsoft.Extensions.Logging;

namespace CoreLMS.Application.Services.CourseLessonService
{
    public class RoleTitleService : IRoleTitleService
    {
        private readonly IRepository<RoleTitle> _repository;
        private readonly ILogger<RoleTitleService> logger;

        public RoleTitleService(IRepository<RoleTitle> repository, ILogger<RoleTitleService> logger)
        {
            this._repository = repository;
            this.logger = logger;
        }



    }
}
