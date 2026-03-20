using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 角色模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RoleController : CommonController<RoleController>
    {
        /// <summary>
        /// 角色模型Service
        /// </summary>
        private IRoleService _RoleService;   

        public RoleController(ILogger<RoleController> logger,
                                IRoleService RoleService) : 
            base(logger)
        {
            _RoleService = RoleService;
        }

        /// <summary>
        /// 查询角色模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Role> Get(int id)
        {
            // 1、查询角色模型
           return await _RoleService.GetAsync(id);
        }

        /// <summary>
        /// 添加角色模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Role Role)
        {
            // 1、添加角色模型
            return await _RoleService.AddAsync(Role);
        }
    }
}