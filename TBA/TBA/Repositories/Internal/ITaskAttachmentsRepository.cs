using TBA.Model;

namespace TBA.Repositories.Internal
{
    public interface ITaskAttachmentsRepository
    {
        Task<IEnumerable<TaskAttachment>> GetAllTaskAttachmentsAsync();
        Task<TaskAttachment> GetTaskAttachmentByIdAsync(int id);
        Task AddTaskAttachmentAsync(TaskAttachment taskAttachment);
        Task UpdateTaskAttachmentAsync(TaskAttachment taskAttachments);
        Task DeleteTaskAttachmentAsync(int id);
    }
}
