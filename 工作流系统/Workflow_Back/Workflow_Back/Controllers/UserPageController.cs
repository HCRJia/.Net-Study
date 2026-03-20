using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Dtos;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 用户页面控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserPageController : CommonController<UserController>
    {
        /// <summary>
        /// 用户模型Service
        /// </summary>
        private IUserService _UserService;   

        public UserPageController(ILogger<UserController> logger,
                                IUserService UserService) : 
            base(logger)
        {
            _UserService = UserService;
        }

        /// <summary>
        /// 1、用户创建
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> UserCreateAsync(UserCreateDto userCreateDto)
        {
            return await _UserService.UserCreateAsync(userCreateDto);
        }

        /// <summary>
        /// 2、用户集合查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<UserDto>> UserGetListAsync(UserGetListDto userGetListDto)
        {
            return null;
        }

        /// <summary>
        /// 3、用户查询【根据用户Id查询】
        /// </summary>
        /// <returns></returns>
        [HttpGet("{UserId}")]
        public async Task<UserDto> UserGetAsync(long UserId)
        {
            return null;
        }

        /// <summary>
        /// 4、用户更新
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> UserUpdateAsync(UserUpdateDto userUpdateDto,long UserId)
        {
            return false;
        }

        /// <summary>
        /// 5、用户删除
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> UserDeleteAsync(List<long> UserIds)
        {
            return false;
        }

        /// <summary>
        /// 6、 用户部门查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserDept")]
        public async Task<UserDeptDto> UserDeptGetAsync(long UserId)
        {
            return null;
        }

        /// <summary>
        /// 6.1、用户部门分配
        /// </summary>
        /// <returns></returns>
        [HttpPut("UserDept")]
        public async Task<bool> UserDeptAssignAsync(UserDeptAssignDto userDeptAssignDto)
        {
            return false;
        }

        /// <summary>
        /// 7、 用户角色查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("UserRole")]
        public async Task<List<UserRoleDto>> UserRoleGetAsync(long UserId)
        {
            return null;
        }

        /// <summary>
        /// 7.1、用户角色分配
        /// </summary>
        /// <returns></returns>
        [HttpPut("UserRole")]
        public async Task<bool> UserRoleAssignAsync(UserRoleAssignDto userRoleAssignDto)
        {
            return false;
        }
        
    }
}