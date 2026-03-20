using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 部门模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class DeptController : CommonController<DeptController>
    {
        /// <summary>
        /// 部门模型Service
        /// </summary>
        private IDeptService _DeptService;   

        public DeptController(ILogger<DeptController> logger,
                                IDeptService DeptService) : 
            base(logger)
        {
            _DeptService = DeptService;
        }

        /// <summary>
        /// 查询部门模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Dept> Get(int id)
        {
            // 1、查询部门模型
           return await _DeptService.GetAsync(id);
        }

        /// <summary>
        /// 添加部门模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Dept Dept)
        {
            // 1、添加部门模型
            return await _DeptService.AddAsync(Dept);
        }
    }
}