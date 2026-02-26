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
    public class SystemController : CommonController<SystemController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private ISystemService _SystemService;   

        public SystemController(ILogger<SystemController> logger,
                                ISystemService SystemService) : 
            base(logger)
        {
            _SystemService = SystemService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Systems> Get(int id)
        {
            // 1、查询
           return await _SystemService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Systems System)
        {
            // 1、添加
            return await _SystemService.AddAsync(System);
        }
    }
}