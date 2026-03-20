using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 流程委托模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowAssignController : CommonController<WorkflowAssignController>
    {
        /// <summary>
        /// 流程委托模型Service
        /// </summary>
        private IWorkflowAssignService _WorkflowAssignService;   

        public WorkflowAssignController(ILogger<WorkflowAssignController> logger,
                                IWorkflowAssignService WorkflowAssignService) : 
            base(logger)
        {
            _WorkflowAssignService = WorkflowAssignService;
        }

        /// <summary>
        /// 查询流程委托模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowAssign> Get(int id)
        {
            // 1、查询流程委托模型
           return await _WorkflowAssignService.GetAsync(id);
        }

        /// <summary>
        /// 添加流程委托模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowAssign WorkflowAssign)
        {
            // 1、添加流程委托模型
            return await _WorkflowAssignService.AddAsync(WorkflowAssign);
        }
    }
}