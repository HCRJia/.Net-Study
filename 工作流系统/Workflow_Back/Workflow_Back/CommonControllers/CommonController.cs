using Microsoft.AspNetCore.Mvc;

namespace Workflow_Back.CommonControllers
{
    /// <summary>
    /// 通用控制器
    /// </summary>
    public abstract class CommonController<T> : ControllerBase
    {
        protected ILogger<T> _logger { get; }

        public CommonController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
