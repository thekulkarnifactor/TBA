using Microsoft.EntityFrameworkCore;
using TBA.Data;
using TBA.Model;
using TBA.Repositories.Internal;

namespace TBA.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teams>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Teams> GetTeamByIdAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task AddTeamAsync(Teams team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeamAsync(Teams team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }
    }
}
