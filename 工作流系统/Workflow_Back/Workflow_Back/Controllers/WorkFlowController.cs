using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;

namespace Workflow_Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkFlowController : CommonController<WorkFlowController>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WorkFlowController(ILogger<WorkFlowController> logger) : base(logger)
        {
        }

        [HttpGet(Name = "WorkFlow")]
        public IEnumerable<WeatherForecast> Get()
        {
            // 1、通用控制器使用
            _logger.LogInformation("通用控制器日志");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
