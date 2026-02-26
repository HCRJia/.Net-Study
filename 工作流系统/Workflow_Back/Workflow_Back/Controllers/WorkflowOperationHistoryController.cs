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
    public class WorkflowOperationHistoryController : CommonController<WorkflowOperationHistoryController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IWorkflowOperationHistoryService _WorkflowOperationHistoryService;   

        public WorkflowOperationHistoryController(ILogger<WorkflowOperationHistoryController> logger,
                                IWorkflowOperationHistoryService WorkflowOperationHistoryService) : 
            base(logger)
        {
            _WorkflowOperationHistoryService = WorkflowOperationHistoryService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowOperationHistory> Get(int id)
        {
            // 1、查询
           return await _WorkflowOperationHistoryService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowOperationHistory WorkflowOperationHistory)
        {
            // 1、添加
            return await _WorkflowOperationHistoryService.AddAsync(WorkflowOperationHistory);
        }
    }
}