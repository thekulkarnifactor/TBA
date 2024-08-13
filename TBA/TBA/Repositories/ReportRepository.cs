using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBA.Data;
using TBA.Model;
using TBA.Repositories.Internal;

namespace TBA.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetTeamTaskReportAsync(DateTime startDate, DateTime endDate, string status)
        {
            var reports = await _context.Tasks
                .Where(t => t.DueDate >= startDate && t.DueDate <= endDate && t.Status == status)
                .ToListAsync();

            return reports;
        }
    }
}
