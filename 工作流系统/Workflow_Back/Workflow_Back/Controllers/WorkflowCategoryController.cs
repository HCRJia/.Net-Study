using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 流程分类模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowCategoryController : CommonController<WorkflowCategoryController>
    {
        /// <summary>
        /// 流程分类模型Service
        /// </summary>
        private IWorkflowCategoryService _WorkflowCategoryService;   

        public WorkflowCategoryController(ILogger<WorkflowCategoryController> logger,
                                IWorkflowCategoryService WorkflowCategoryService) : 
            base(logger)
        {
            _WorkflowCategoryService = WorkflowCategoryService;
        }

        /// <summary>
        /// 查询流程分类模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowCategory> Get(int id)
        {
            // 1、查询流程分类模型
           return await _WorkflowCategoryService.GetAsync(id);
        }

        /// <summary>
        /// 添加流程分类模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowCategory WorkflowCategory)
        {
            // 1、添加流程分类模型
            return await _WorkflowCategoryService.AddAsync(WorkflowCategory);
        }
    }
}