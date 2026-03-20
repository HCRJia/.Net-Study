using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 用户角色关联模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserRoleController : CommonController<UserRoleController>
    {
        /// <summary>
        /// 用户角色关联模型Service
        /// </summary>
        private IUserRoleService _UserRoleService;   

        public UserRoleController(ILogger<UserRoleController> logger,
                                IUserRoleService UserRoleService) : 
            base(logger)
        {
            _UserRoleService = UserRoleService;
        }

        /// <summary>
        /// 查询用户角色关联模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<UserRole> Get(int id)
        {
            // 1、查询用户角色关联模型
           return await _UserRoleService.GetAsync(id);
        }

        /// <summary>
        /// 添加用户角色关联模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(UserRole UserRole)
        {
            // 1、添加用户角色关联模型
            return await _UserRoleService.AddAsync(UserRole);
        }
    }
}