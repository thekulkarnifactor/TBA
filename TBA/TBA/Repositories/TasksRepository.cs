using Microsoft.EntityFrameworkCore;
using TBA.Data;
using TBA.Model;
using TBA.Repositories.Internal;

namespace TBA.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ApplicationDbContext _context;

        public TasksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetTasksByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task AddTasksAsync(Tasks tasks)
        {
            await _context.Tasks.AddAsync(tasks);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTasksAsync(Tasks tasks)
        {
            _context.Tasks.Update(tasks);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTasksAsync(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks != null)
            {
                _context.Tasks.Remove(tasks);
                await _context.SaveChangesAsync();
            }
        }
    }
}
