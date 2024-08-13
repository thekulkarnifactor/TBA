namespace TBA.Model
{
    public class TaskReportRequestDto
    {
        public string Status { get; set; }  // Open, InProgress, Completed
        public string TimeRange { get; set; }  // Week, Month
    }
}
