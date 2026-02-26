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
    public class WorkflowController : CommonController<WorkflowController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IWorkflowService _WorkflowService;   

        public WorkflowController(ILogger<WorkflowController> logger,
                                IWorkflowService WorkflowService) : 
            base(logger)
        {
            _WorkflowService = WorkflowService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Workflow> Get(int id)
        {
            // 1、查询
           return await _WorkflowService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Workflow Workflow)
        {
            // 1、添加
            return await _WorkflowService.AddAsync(Workflow);
        }
    }
}