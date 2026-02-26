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
    public class WorkflowFormController : CommonController<WorkflowFormController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IWorkflowFormService _WorkflowFormService;   

        public WorkflowFormController(ILogger<WorkflowFormController> logger,
                                IWorkflowFormService WorkflowFormService) : 
            base(logger)
        {
            _WorkflowFormService = WorkflowFormService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowForm> Get(int id)
        {
            // 1、查询
           return await _WorkflowFormService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowForm WorkflowForm)
        {
            // 1、添加
            return await _WorkflowFormService.AddAsync(WorkflowForm);
        }
    }
}