using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 子系统模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SystemsController : CommonController<SystemsController>
    {
        /// <summary>
        /// 子系统模型Service
        /// </summary>
        private ISystemsService _SystemsService;   

        public SystemsController(ILogger<SystemsController> logger,
                                ISystemsService SystemsService) : 
            base(logger)
        {
            _SystemsService = SystemsService;
        }

        /// <summary>
        /// 查询子系统模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Systems> Get(int id)
        {
            // 1、查询子系统模型
           return await _SystemsService.GetAsync(id);
        }

        /// <summary>
        /// 添加子系统模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Systems Systems)
        {
            // 1、添加子系统模型
            return await _SystemsService.AddAsync(Systems);
        }
    }
}