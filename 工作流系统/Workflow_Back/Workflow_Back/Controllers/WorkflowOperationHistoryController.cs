using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 流程操作历史模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowOperationHistoryController : CommonController<WorkflowOperationHistoryController>
    {
        /// <summary>
        /// 流程操作历史模型Service
        /// </summary>
        private IWorkflowOperationHistoryService _WorkflowOperationHistoryService;   

        public WorkflowOperationHistoryController(ILogger<WorkflowOperationHistoryController> logger,
                                IWorkflowOperationHistoryService WorkflowOperationHistoryService) : 
            base(logger)
        {
            _WorkflowOperationHistoryService = WorkflowOperationHistoryService;
        }

        /// <summary>
        /// 查询流程操作历史模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowOperationHistory> Get(int id)
        {
            // 1、查询流程操作历史模型
           return await _WorkflowOperationHistoryService.GetAsync(id);
        }

        /// <summary>
        /// 添加流程操作历史模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowOperationHistory WorkflowOperationHistory)
        {
            // 1、添加流程操作历史模型
            return await _WorkflowOperationHistoryService.AddAsync(WorkflowOperationHistory);
        }
    }
}