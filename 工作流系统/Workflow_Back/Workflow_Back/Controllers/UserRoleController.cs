using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserRoleController : CommonController<UserRoleController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IUserRoleService _UserRoleService;   

        public UserRoleController(ILogger<UserRoleController> logger,
                                IUserRoleService UserRoleService) : 
            base(logger)
        {
            _UserRoleService = UserRoleService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<UserRole> Get(int id)
        {
            // 1、查询
           return await _UserRoleService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(UserRole UserRole)
        {
            // 1、添加
            return await _UserRoleService.AddAsync(UserRole);
        }
    }
}