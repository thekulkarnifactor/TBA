using Microsoft.AspNetCore.Mvc;
using TBA.Model;
using TBA.Repositories.Internal;

namespace TBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpPost("TeamTaskReport")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTeamTaskReport([FromBody] TaskReportRequestDto request)
        {
            DateTime startDate;
            DateTime endDate = DateTime.Now;

            if (request.TimeRange.ToLower() == "week")
            {
                startDate = DateTime.Now.AddDays(-7);
            }
            else if (request.TimeRange.ToLower() == "month")
            {
                startDate = DateTime.Now.AddMonths(-1);
            }
            else
            {
                return BadRequest("Invalid TimeRange specified. Use 'Week' or 'Month'.");
            }

            var reports = await _reportRepository.GetTeamTaskReportAsync(startDate, endDate, request.Status);
            return Ok(reports);
        }
    }
}