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
    public class WorkflowsqlController : CommonController<WorkflowsqlController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IWorkflowsqlService _WorkflowsqlService;   

        public WorkflowsqlController(ILogger<WorkflowsqlController> logger,
                                IWorkflowsqlService WorkflowsqlService) : 
            base(logger)
        {
            _WorkflowsqlService = WorkflowsqlService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Workflowsql> Get(int id)
        {
            // 1、查询
           return await _WorkflowsqlService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Workflowsql Workflowsql)
        {
            // 1、添加
            return await _WorkflowsqlService.AddAsync(Workflowsql);
        }
    }
}