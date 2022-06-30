using Kevin.T.Clockify.Data.Entities;
using System.Threading.Tasks;

namespace CoreLMS.Core.Interfaces
{
    public interface ITimeEntryService : IBaseService<TimeEntry>
    {
        Task<int> SyncFromClockify(string startDate, string endDate);
    }
}
