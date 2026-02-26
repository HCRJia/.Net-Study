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
    public class ResourceController : CommonController<ResourceController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IResourceService _ResourceService;   

        public ResourceController(ILogger<ResourceController> logger,
                                IResourceService ResourceService) : 
            base(logger)
        {
            _ResourceService = ResourceService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Resource> Get(int id)
        {
            // 1、查询
           return await _ResourceService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Resource Resource)
        {
            // 1、添加
            return await _ResourceService.AddAsync(Resource);
        }
    }
}