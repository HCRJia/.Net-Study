using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 流程实例表单关联模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowInstanceFormController : CommonController<WorkflowInstanceFormController>
    {
        /// <summary>
        /// 流程实例表单关联模型Service
        /// </summary>
        private IWorkflowInstanceFormService _WorkflowInstanceFormService;   

        public WorkflowInstanceFormController(ILogger<WorkflowInstanceFormController> logger,
                                IWorkflowInstanceFormService WorkflowInstanceFormService) : 
            base(logger)
        {
            _WorkflowInstanceFormService = WorkflowInstanceFormService;
        }

        /// <summary>
        /// 查询流程实例表单关联模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowInstanceForm> Get(int id)
        {
            // 1、查询流程实例表单关联模型
           return await _WorkflowInstanceFormService.GetAsync(id);
        }

        /// <summary>
        /// 添加流程实例表单关联模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowInstanceForm WorkflowInstanceForm)
        {
            // 1、添加流程实例表单关联模型
            return await _WorkflowInstanceFormService.AddAsync(WorkflowInstanceForm);
        }
    }
}