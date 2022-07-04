using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using Microsoft.Extensions.Logging;

namespace CoreLMS.Application.Services.CourseLessonService
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IRepository<ProjectTask> _repository;
        private readonly ILogger<ProjectTaskService> logger;

        public ProjectTaskService(IRepository<ProjectTask> repository, ILogger<ProjectTaskService> logger)
        {
            this._repository = repository;
            this.logger = logger;
        }



    }
}
