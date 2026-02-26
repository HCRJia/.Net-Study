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
    public class WorkflowCategoryController : CommonController<WorkflowCategoryController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IWorkflowCategoryService _WorkflowCategoryService;   

        public WorkflowCategoryController(ILogger<WorkflowCategoryController> logger,
                                IWorkflowCategoryService WorkflowCategoryService) : 
            base(logger)
        {
            _WorkflowCategoryService = WorkflowCategoryService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowCategory> Get(int id)
        {
            // 1、查询
           return await _WorkflowCategoryService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowCategory WorkflowCategory)
        {
            // 1、添加
            return await _WorkflowCategoryService.AddAsync(WorkflowCategory);
        }
    }
}