using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using Kevin.T.Clockify.Data.Entities;
using Microsoft.Extensions.Logging;

namespace CoreLMS.Application.Services
{
    public partial class TimeEntryService : ITimeEntryService
    {
        private readonly IRepository<TimeEntry> _repository;
        private readonly ILogger<TimeEntryService> _logger;

        public TimeEntryService(IAppDbContext unitOfWork, ILogger<TimeEntryService> logger)
        {
            _logger = logger;
            _repository = new Repository<TimeEntry>(unitOfWork);
        }



    }
}
