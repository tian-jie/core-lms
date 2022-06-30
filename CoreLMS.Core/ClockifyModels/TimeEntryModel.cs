using System.Collections.Generic;

namespace Kevin.T.Clockify.Data.Models
{
    public class TimeEntryModel
    {
        public string _id { get; set; }
        public string description { get; set; }
        public string clientId { get; set; }
        public string clientName { get; set; }
        public bool isLocked { get; set; }
        public string projectColor { get; set; }
        public string projectId { get; set; }
        public string projectName { get; set; }
        public string taskId { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public bool billable { get; set; }
        public TimeIntervalModel timeInterval { get; set; }


        //public List<string> customFieldValues { get; set; }
        //public UserModel user { get; set; }
        //public TaskModel task { get; set; }
        //public ProjectModel project { get; set; }
        //public string workspaceId { get; set; }
        //public float totalBillable { get; set; }
        //public float totalBillableDecimal { get; set; }
        //public HourlyRateModel hourlyRate { get; set; }
    }
}
