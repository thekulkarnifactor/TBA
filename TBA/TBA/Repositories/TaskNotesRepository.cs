using Microsoft.EntityFrameworkCore;
using TBA.Data;
using TBA.Model;
using TBA.Repositories.Internal;

namespace TBA.Repositories
{
    public class TaskNotesRepository : ITaskNotesRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskNotesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskNotes>> GetAllTaskNotesAsync()
        {
            return await _context.TaskNotes.ToListAsync();
        }

        public async Task<TaskNotes> GetTaskNoteByIdAsync(int id)
        {
            return await _context.TaskNotes.FindAsync(id);
        }

        public async Task AddTaskNoteAsync(TaskNotes taskNotes)
        {
            await _context.TaskNotes.AddAsync(taskNotes);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskNoteAsync(TaskNotes taskNotes)
        {
            _context.TaskNotes.Update(taskNotes);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskNoteAsync(int id)
        {
            var taskNotes = await _context.TaskNotes.FindAsync(id);
            if (taskNotes != null)
            {
                _context.TaskNotes.Remove(taskNotes);
                await _context.SaveChangesAsync();
            }
        }
    }
}
