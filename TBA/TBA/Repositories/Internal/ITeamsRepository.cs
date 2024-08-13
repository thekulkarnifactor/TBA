using TBA.Model;

namespace TBA.Repositories.Internal
{
    public interface ITeamsRepository
    {
        Task<IEnumerable<Teams>> GetAllTeamsAsync();
        Task<Teams> GetTeamByIdAsync(int id);
        Task AddTeamAsync(Teams team);
        Task UpdateTeamAsync(Teams team);
        Task DeleteTeamAsync(int id);
    }
}
