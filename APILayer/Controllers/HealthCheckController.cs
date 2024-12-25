using Microsoft.AspNetCore.Mvc;
using DataLayer;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HealthCheckController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("db-status")]
        public async Task<IActionResult> CheckDatabaseConnection()
        {
            var canConnect = await _context.CanConnectAsync();
            return Ok(new { DatabaseConnection = canConnect });
        }
    }
}