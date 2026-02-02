using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonExceptions;
using Workflow_Back.CommonResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Workflow_Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Get")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetIActionResult1")]
        public CommonResult GetIActionResult1()
        {
            CommonResult result = new CommonResult()
            {
                ErrorNo = "0",
                ErrorInfo = "成功",
                Result = "这是一个IActionResult返回值的示例"
            };
            return result;
        }

        [HttpGet("GetImplementedException")]
        public void GetImplementedException()
        {
            CommonException exception = new()
            {
                ErrorNo = "1",
                ErrorInfo = "这是一个已实现的异常示例"
            };
            throw exception;
        }
    }
}
