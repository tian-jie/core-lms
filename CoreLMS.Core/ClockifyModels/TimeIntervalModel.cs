namespace Kevin.T.Clockify.Data.Models
{
    public class TimeIntervalModel
    {
        public string start { get; set; }
        public string end { get; set; }

        /// <summary>
        /// duration，以秒计算
        /// </summary>
        public long duration { get; set; }
    }
}
