using System.Collections.Generic;

namespace Kevin.T.Clockify.Data.Models
{
    public class TimeEntryResponseModel
    {
        public List<TimeEntryModel> timeentries { get; set; }
        public List<TimeEntryReponseTotalModel> totals { get; set; }
    }

    public class TimeEntryReponseTotalModel
    {
        public List<int> amounts { get; set; }
        public int entriesCount { get; set; }
        public int? totalAmount { get; set; }
        public long totalTime { get; set; }
    }
}
