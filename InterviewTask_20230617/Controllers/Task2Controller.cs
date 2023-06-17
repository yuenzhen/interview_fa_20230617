using InterviewTask_20230617.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask_20230617.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Task2Controller : ControllerBase
    {
        private readonly ILogger<Task2Controller> _logger;
        private readonly ITask2Service _task2Service;

        public Task2Controller(ILogger<Task2Controller> logger, ITask2Service task2Service)
        {
            _logger = logger;
            _task2Service = task2Service;
        }

        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBasicAnswer([FromQuery] string input)
        {
            try
            {
                return Ok(_task2Service.GetReferenceNumber(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Advance")]
        public IActionResult GetAdvanceAnswer([FromQuery] int stringSize, [FromQuery] int sampleSize)
        {
            try
            {
                return Ok(_task2Service.FindDistribution(stringSize, sampleSize));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
