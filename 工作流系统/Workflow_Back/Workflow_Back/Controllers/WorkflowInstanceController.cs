using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 流程实例模型【根据流程运行流程】控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowInstanceController : CommonController<WorkflowInstanceController>
    {
        /// <summary>
        /// 流程实例模型【根据流程运行流程】Service
        /// </summary>
        private IWorkflowInstanceService _WorkflowInstanceService;   

        public WorkflowInstanceController(ILogger<WorkflowInstanceController> logger,
                                IWorkflowInstanceService WorkflowInstanceService) : 
            base(logger)
        {
            _WorkflowInstanceService = WorkflowInstanceService;
        }

        /// <summary>
        /// 查询流程实例模型【根据流程运行流程】Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowInstance> Get(int id)
        {
            // 1、查询流程实例模型【根据流程运行流程】
           return await _WorkflowInstanceService.GetAsync(id);
        }

        /// <summary>
        /// 添加流程实例模型【根据流程运行流程】
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowInstance WorkflowInstance)
        {
            // 1、添加流程实例模型【根据流程运行流程】
            return await _WorkflowInstanceService.AddAsync(WorkflowInstance);
        }
    }
}