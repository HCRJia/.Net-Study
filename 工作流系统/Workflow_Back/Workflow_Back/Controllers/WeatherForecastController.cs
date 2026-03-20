using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonExceptions;
using Workflow_Back.CommonResults;

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

        [HttpGet(Name = "GetWeatherForecast")]
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

        [HttpGet("GetIActionResult")]
        public IActionResult GetIActionResult()
        {
            return null;
        }

        [HttpGet("GetString")]
        public CommonResult GetString()
        {
            // 1、创建CommonResult 
            CommonResult commonResult = new CommonResult();
            commonResult.ErrorNo = "0";
            commonResult.Result = "字符串查询成功";

            // 2、返回CommonResult
            return commonResult;
        }

        [HttpGet("GetVoid")] 
        public void GetVoid()
        {

        }

        [HttpGet("GetJson")]
        public JsonResult GetJson()
        {
            return new JsonResult("json结果");
        }

        [HttpGet("GetStatusCodeResult")]
        public StatusCodeResult GetStatusCodeResult()
        {
            return new StatusCodeResult(200);
        }

        [HttpGet("GetExceptions")]
        public StatusCodeResult GetExceptions()
        {
            throw new Exception("抛出一个异常");
            return new StatusCodeResult(200);
        }

        [HttpGet("GetImplementedException")]
        public StatusCodeResult GetImplementedException()
        {
            // 1、未实现异常
            NotImplementedException notImplementedException =
                new NotImplementedException("抛出一个异常");

            // 2、未实现异常包装
            CommonException commonException = new CommonException();
            commonException.ErrorNo = "-2"; // 异常编号
            commonException.ErrorInfo = notImplementedException.Message;

            // 3、异常返回
            throw commonException;
            return new StatusCodeResult(200);
        }
    }
}
