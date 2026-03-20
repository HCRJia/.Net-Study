using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 流程表单模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowFormController : CommonController<WorkflowFormController>
    {
        /// <summary>
        /// 流程表单模型Service
        /// </summary>
        private IWorkflowFormService _WorkflowFormService;   

        public WorkflowFormController(ILogger<WorkflowFormController> logger,
                                IWorkflowFormService WorkflowFormService) : 
            base(logger)
        {
            _WorkflowFormService = WorkflowFormService;
        }

        /// <summary>
        /// 查询流程表单模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowForm> Get(int id)
        {
            // 1、查询流程表单模型
           return await _WorkflowFormService.GetAsync(id);
        }

        /// <summary>
        /// 添加流程表单模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowForm WorkflowForm)
        {
            // 1、添加流程表单模型
            return await _WorkflowFormService.AddAsync(WorkflowForm);
        }
    }
}