using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 流程流转历史模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowTransitionHistoryController : CommonController<WorkflowTransitionHistoryController>
    {
        /// <summary>
        /// 流程流转历史模型Service
        /// </summary>
        private IWorkflowTransitionHistoryService _WorkflowTransitionHistoryService;   

        public WorkflowTransitionHistoryController(ILogger<WorkflowTransitionHistoryController> logger,
                                IWorkflowTransitionHistoryService WorkflowTransitionHistoryService) : 
            base(logger)
        {
            _WorkflowTransitionHistoryService = WorkflowTransitionHistoryService;
        }

        /// <summary>
        /// 查询流程流转历史模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowTransitionHistory> Get(int id)
        {
            // 1、查询流程流转历史模型
           return await _WorkflowTransitionHistoryService.GetAsync(id);
        }

        /// <summary>
        /// 添加流程流转历史模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowTransitionHistory WorkflowTransitionHistory)
        {
            // 1、添加流程流转历史模型
            return await _WorkflowTransitionHistoryService.AddAsync(WorkflowTransitionHistory);
        }
    }
}