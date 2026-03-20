using Workflow_Back.Dtos;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 登录Service接口
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns></returns>
        public Task<UserLoginResultDto> UserLoginAsync(UserLoginDto userLoginDto);

    }
}
