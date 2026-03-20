using Microsoft.AspNetCore.Mvc;
using Workflow_CommonController.CommonControllers;

namespace Workflow_Back.CommonControllers
{
    /// <summary>
    /// 通用控制器
    /// </summary>
    public abstract class CommonController<T> : ControllerBase
    {
        protected ILogger<T> _logger { get; }

        public SysUser _SysUser => base.User.ToSysUser(); // 每次获取最新出的SysUser

        public CommonController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
