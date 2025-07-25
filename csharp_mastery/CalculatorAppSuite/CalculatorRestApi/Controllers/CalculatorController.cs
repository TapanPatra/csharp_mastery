using Microsoft.AspNetCore.Mvc;
using CalculatorRestApi.Services;

namespace CalculatorRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly Calculator _calculator = new Calculator();

        [HttpGet("add")]
        public IActionResult Add(double a, double b) => Ok(_calculator.Add(a, b));

        [HttpGet("subtract")]
        public IActionResult Subtract(double a, double b) => Ok(_calculator.Subtract(a, b));

        [HttpGet("multiply")]
        public IActionResult Multiply(double a, double b) => Ok(_calculator.Multiply(a, b));

        [HttpGet("divide")]
        public IActionResult Divide(double a, double b)
        {
            try
            {
                return Ok(_calculator.Divide(a, b));
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
