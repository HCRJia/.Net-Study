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
    /// 登录控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LoginController : CommonController<UserController>
    {
        private readonly ILoginService _loginService;
        
        public LoginController(ILogger<UserController>  logger,
                            ILoginService loginService) : 
            base(logger)
        {
            _loginService = loginService;
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

        /// <summary>
        /// 用户登录结果获取
        /// </summary>
        [HttpPost("SysUser")]
        [Authorize]
        public async Task<SysUser> GetUserLoginResultAsync()
        {
            // 1、用户登录结果获取
            string UserName = _SysUser.UserName;
            return _SysUser;
        }


        /// <summary>
        /// 4.1、实现用户登录
        /// </summary>
        /// <param name="userLoginResultDto"></param>
        /// <returns></returns>
        private async Task UserLoginResultSave(UserLoginResultDto userLoginResultDto)
        {
            // 1、创建声明
            List<Claim> list = new List<Claim>();
            list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userLoginResultDto.UserName));
            list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender", ((int)userLoginResultDto.Sex).ToString()));
            list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid", userLoginResultDto.UserId.ToString()));
            if (!string.IsNullOrEmpty(userLoginResultDto.HeadImg))
            {
                list.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/uri", userLoginResultDto.HeadImg));
            }

            if (userLoginResultDto.Other != null)
            {
                list.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", 
                        JsonConvert.SerializeObject(userLoginResultDto.Other)));
            }

            // 2、创建用户身份
            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaims(list);

            // 3、使用Cookie实现登录
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(identity));
        }



    }
}