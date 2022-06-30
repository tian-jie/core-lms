using CoreLMS.Core.Interfaces;
using Kevin.T.Clockify.Data.Entities;
using System.Threading.Tasks;

namespace CoreLMS.Application.Services
{
    public class TimeEntryService : BaseService<TimeEntry>, ITimeEntryService
    {
        public TimeEntryService(IAppDbContext unitOfWork)
            : base(unitOfWork)
        {
            
        }

        public async Task<int> SyncFromClockify(string startDate, string endDate)
        {
            return 0;
        }






    }
}
