namespace TBA.Model
{
    public class TaskNotes
    {
        public int NoteId { get; set; }
        public int TaskId { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        //public virtual Tasks Task { get; set; }
        //public virtual Employee Creator { get; set; }
    }
}
