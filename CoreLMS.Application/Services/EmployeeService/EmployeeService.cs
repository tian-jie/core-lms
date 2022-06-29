using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using Kevin.T.Clockify.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLMS.Application.Services.CourseLessonService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly ILogger<EmployeeService> logger;

        public EmployeeService(IRepository<Employee> repository, ILogger<EmployeeService> logger)
        {
            this._repository = repository;
            this.logger = logger;
        }


        public async Task UpdateSharepointPeopleAsync(string date, string sharepointText)
        {
            //_repository
        }

    }
}
