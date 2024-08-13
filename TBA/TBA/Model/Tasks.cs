namespace TBA.Model
{
    public class Tasks
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedTo { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        //public virtual Employee Creator { get; set; }
        //public virtual Employee Assignee { get; set; }
        //public virtual ICollection<TaskNote> Notes { get; set; }
        //public virtual ICollection<TaskAttachment> Attachments { get; set; }
    }
}
