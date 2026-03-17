using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Dtos;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    public class LoginController : CommonController<LoginController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private ILoginService _LoginService;

        public LoginController(ILogger<LoginController> logger,
                                ILoginService LoginService) :
            base(logger)
        {
            _LoginService = LoginService;
        }

        /// <summary>
        /// 用户登录接口
        /// </summary>
        [HttpPost]
        public async Task<UserLoginResultDto> UserLoginAsync(UserLoginDto userLoginDto)
        {
            // 1、登录结果获取
            UserLoginResultDto userLoginResultDto = await _loginService.UserLoginAsync(userLoginDto);

            // 2、登录结果存储
            await UserLoginResultSave(userLoginResultDto);

            return userLoginResultDto;
        }
    }
}
