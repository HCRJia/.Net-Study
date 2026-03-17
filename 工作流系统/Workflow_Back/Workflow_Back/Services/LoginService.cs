using AutoMapper;
using JadeFramework.Core.Extensions;
using JadeFramework.Core.Security;
using Workflow_Back.CommonExceptions;
using Workflow_Back.Contexts;
using Workflow_Back.Dtos;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public class LoginService : ILoginService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }
        private readonly IMapper _mapper;  // 映射接口

        public LoginService(WorkflowFixtrue workflowFixtrue,
                           IMapper mapper)
        {
            _workflowFixtrue = workflowFixtrue;
            _mapper = mapper;
        }

        /// <summary>
        /// 用户登录实现
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns></returns>
        public async Task<UserLoginResultDto> UserLoginAsync(UserLoginDto userLoginDto)
        {
            // 1、用户名和密码校验
            if (userLoginDto.UserName.IsNullOrEmpty()
                || userLoginDto.Password.IsNullOrEmpty())
            {
                throw new CommonException("请输入用户名或密码");
            }

            // 2、用户判断
            // 2.1、用户密码加密
            string pwd = EncryptProvider.CreateSha1Code(userLoginDto.Password);
            User user = await _workflowFixtrue.db._UserRepository.FindAsync(
                        m => m.IsDel == false // 未删除
                        && m.UserName == userLoginDto.UserName.TrimBlank()
                        && m.Password == userLoginDto.Password);
            if (user == null)
            {
                throw new CommonException("用户名或密码错误！");
            }

            // 3、用户映射
            UserLoginResultDto userLoginResultDto = _mapper.Map<UserLoginResultDto>(user);

            // 4、用户登录结果返回
            return userLoginResultDto;
        }
    }
}