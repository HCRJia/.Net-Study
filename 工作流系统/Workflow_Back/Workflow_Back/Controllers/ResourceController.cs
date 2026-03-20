using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 资源【菜单】模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ResourceController : CommonController<ResourceController>
    {
        /// <summary>
        /// 资源【菜单】模型Service
        /// </summary>
        private IResourceService _ResourceService;   

        public ResourceController(ILogger<ResourceController> logger,
                                IResourceService ResourceService) : 
            base(logger)
        {
            _ResourceService = ResourceService;
        }

        /// <summary>
        /// 查询资源【菜单】模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Resource> Get(int id)
        {
            // 1、查询资源【菜单】模型
           return await _ResourceService.GetAsync(id);
        }

        /// <summary>
        /// 添加资源【菜单】模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Resource Resource)
        {
            // 1、添加资源【菜单】模型
            return await _ResourceService.AddAsync(Resource);
        }
    }
}