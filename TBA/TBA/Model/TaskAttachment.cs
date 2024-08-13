namespace TBA.Model
{
    public class TaskAttachment
    {
        public int? AttachmentId { get; set; }
        public int TaskId { get; set; }
        public string? FilePath { get; set; }
        public int UploadedBy { get; set; }
        public DateTime UploadedDate { get; set; }

        //public virtual Tasks Task { get; set; }
        //public virtual Employee Uploader { get; set; }
    }
}
