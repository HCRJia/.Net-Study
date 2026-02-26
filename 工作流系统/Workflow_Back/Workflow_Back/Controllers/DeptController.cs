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
    public class DeptController : CommonController<DeptController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IDeptService _DeptService;   

        public DeptController(ILogger<DeptController> logger,
                                IDeptService DeptService) : 
            base(logger)
        {
            _DeptService = DeptService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Dept> Get(int id)
        {
            // 1、查询
           return await _DeptService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Dept Dept)
        {
            // 1、添加
            return await _DeptService.AddAsync(Dept);
        }
    }
}