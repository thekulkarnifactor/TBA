using TBA.Model;

namespace TBA.Repositories.Internal
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTasksByIdAsync(int id);
        Task AddTasksAsync(Tasks tasks);
        Task UpdateTasksAsync(Tasks tasks);
        Task DeleteTasksAsync(int id);
    }
}
