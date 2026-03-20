using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Workflow_Back.CommonControllers;
using Workflow_Back.Dtos;
using Workflow_Back.Models;
using Workflow_Back.Services;
using Workflow_CommonController.CommonControllers;
using Microsoft.AspNetCore.Authorization;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 登录注销控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LoginoutController : CommonController<UserController>
    {
        private readonly ILoginService _loginService;
        
        public LoginoutController(ILogger<UserController>  logger,
                            ILoginService loginService) : 
            base(logger)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// 用户登录注销接口
        /// </summary>
        [HttpPost]
        public async Task<UserLoginoutResultDto> UserLoginoutAsync()
        {
            // 1、用户登录注销
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // 2、用户登录注销结果
            UserLoginoutResultDto userLoginoutResultDto = new UserLoginoutResultDto();
            userLoginoutResultDto.Success = "true";
            return userLoginoutResultDto;
        }
    }
}