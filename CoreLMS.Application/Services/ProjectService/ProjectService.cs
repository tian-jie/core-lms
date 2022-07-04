using CoreLMS.Application.ViewModels;
using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using Kevin.T.Clockify.Data.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CoreLMS.Application.Services.CourseLessonService
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly ILogger<ProjectService> logger;
        private readonly IRepository<TimeEntry> _timeEntryRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<RoleTitle> _roleTitleRepository;

        public ProjectService(IRepository<Project> repository, ILogger<ProjectService> logger)
        {
            this._projectRepository = repository;
            this.logger = logger;
        }


        public List<ProjectCostViewModel> AccountAllProjectCost()
        {
            var r = from _projectRepository.
        }


    }
}
