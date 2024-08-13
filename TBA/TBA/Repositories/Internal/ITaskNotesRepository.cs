using TBA.Model;

namespace TBA.Repositories.Internal
{
    public interface ITaskNotesRepository
    {
        Task<IEnumerable<TaskNotes>> GetAllTaskNotesAsync();
        Task<TaskNotes> GetTaskNoteByIdAsync(int id);
        Task AddTaskNoteAsync(TaskNotes taskNotes);
        Task UpdateTaskNoteAsync(TaskNotes taskNotes);
        Task DeleteTaskNoteAsync(int id);
    }
}
