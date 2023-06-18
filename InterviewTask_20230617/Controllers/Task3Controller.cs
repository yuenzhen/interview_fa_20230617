using InterviewTask_20230617.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask_20230617.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Task3Controller : ControllerBase
    {
        private readonly ILogger<Task3Controller> _logger;
        private readonly ITask3Service _task3Service;

        public Task3Controller(ILogger<Task3Controller> logger, ITask3Service task3Service)
        {
            _logger = logger;
            _task3Service = task3Service;
        }

        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBasicAnswer([FromQuery] string input, int order)
        {
            try
            {
                return Ok(_task3Service.Task3Basic(input.ToCharArray(), order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
