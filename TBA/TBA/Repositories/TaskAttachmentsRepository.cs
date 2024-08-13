using Microsoft.EntityFrameworkCore;
using TBA.Data;
using TBA.Model;
using TBA.Repositories.Internal;

namespace TBA.Repositories
{
    public class TaskAttachmentsRepository : ITaskAttachmentsRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskAttachmentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskAttachment>> GetAllTaskAttachmentsAsync()
        {
            return await _context.TaskAttachments.ToListAsync();
        }

        public async Task<TaskAttachment> GetTaskAttachmentByIdAsync(int id)
        {
            return await _context.TaskAttachments.FindAsync(id);
        }

        public async Task AddTaskAttachmentAsync(TaskAttachment taskAttachments)
        {
            await _context.TaskAttachments.AddAsync(taskAttachments);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAttachmentAsync(TaskAttachment taskAttachments)
        {
            _context.TaskAttachments.Update(taskAttachments);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAttachmentAsync(int id)
        {
            var taskAttachments = await _context.TaskAttachments.FindAsync(id);
            if (taskAttachments != null)
            {
                _context.TaskAttachments.Remove(taskAttachments);
                await _context.SaveChangesAsync();
            }
        }
    }
}
