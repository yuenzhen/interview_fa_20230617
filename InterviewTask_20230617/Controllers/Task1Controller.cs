using InterviewTask_20230617.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask_20230617.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Task1Controller : ControllerBase
    {
        private readonly ILogger<Task1Controller> _logger;
        private readonly ITask1Service _task1Service;

        public Task1Controller(ILogger<Task1Controller> logger, ITask1Service task1Service)
        {
            _logger = logger;
            _task1Service = task1Service;
        }

        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBasicAnswer([FromQuery]double principalAmount, [FromQuery] int loanPeriodInYear)
        {
            try
            {
                return Ok(_task1Service.CalculateMonthlyRepayment(principalAmount, loanPeriodInYear));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet]
        [Route("Advance1")]
        public IActionResult GetAdvance1Answer([FromQuery] double target)
        {
            try
            {
                int loanPeriodInYear = 5;
                //use the same variable as the Basic question
                var monthlyRepayment = _task1Service.CalculateMonthlyRepayment(95000, loanPeriodInYear, true);
                bool isLessThanInitial = target < monthlyRepayment;

                if (isLessThanInitial)
                {
                    do
                    {
                        loanPeriodInYear += 1;
                        monthlyRepayment = _task1Service.CalculateMonthlyRepayment(95000, loanPeriodInYear, true);
                    } while (monthlyRepayment >= target);
                }
                else
                {
                    do
                    {
                        loanPeriodInYear -= 1;
                        monthlyRepayment = _task1Service.CalculateMonthlyRepayment(95000, loanPeriodInYear, true);
                    } while (monthlyRepayment <= target);
                }

                return Ok(loanPeriodInYear);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Advance2")]
        public IActionResult GetAdvance2Answer([FromQuery] double target)
        {
            try
            {
                double principalAmount = 10000;
                var monthlyRepayment = _task1Service.CalculateMonthlyRepayment(principalAmount, 20, true);
                do
                {
                    principalAmount += 1;
                    monthlyRepayment = _task1Service.CalculateMonthlyRepayment(principalAmount, 20, true);
                    if (!double.IsNaN(monthlyRepayment) && monthlyRepayment >= target)
                        break;
                } while (!double.IsNaN(monthlyRepayment) && monthlyRepayment < target);
                return Ok(principalAmount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
