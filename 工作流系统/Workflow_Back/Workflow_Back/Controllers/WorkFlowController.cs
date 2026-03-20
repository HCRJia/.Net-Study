using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 工作流模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowController : CommonController<WorkflowController>
    {
        /// <summary>
        /// 工作流模型Service
        /// </summary>
        private IWorkflowService _WorkflowService;   

        public WorkflowController(ILogger<WorkflowController> logger,
                                IWorkflowService WorkflowService) : 
            base(logger)
        {
            _WorkflowService = WorkflowService;
        }

        /// <summary>
        /// 查询工作流模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Workflow> Get(int id)
        {
            // 1、查询工作流模型
           return await _WorkflowService.GetAsync(id);
        }

        /// <summary>
        /// 添加工作流模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Workflow Workflow)
        {
            // 1、添加工作流模型
            return await _WorkflowService.AddAsync(Workflow);
        }
    }
}