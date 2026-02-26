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
    public class RoleResourceController : CommonController<RoleResourceController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IRoleResourceService _RoleResourceService;   

        public RoleResourceController(ILogger<RoleResourceController> logger,
                                IRoleResourceService RoleResourceService) : 
            base(logger)
        {
            _RoleResourceService = RoleResourceService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<RoleResource> Get(int id)
        {
            // 1、查询
           return await _RoleResourceService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(RoleResource RoleResource)
        {
            // 1、添加
            return await _RoleResourceService.AddAsync(RoleResource);
        }
    }
}