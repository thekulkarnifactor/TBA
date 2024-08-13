using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBA.Model;

namespace TBA.Repositories.Internal
{
    public interface IReportRepository
    {
        Task<IEnumerable<Tasks>> GetTeamTaskReportAsync(DateTime startDate, DateTime endDate, string status);
    }
}
