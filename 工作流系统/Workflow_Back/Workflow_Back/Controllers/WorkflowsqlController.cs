using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 工作流获取权限系统数据模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowsqlController : CommonController<WorkflowsqlController>
    {
        /// <summary>
        /// 工作流获取权限系统数据模型Service
        /// </summary>
        private IWorkflowsqlService _WorkflowsqlService;   

        public WorkflowsqlController(ILogger<WorkflowsqlController> logger,
                                IWorkflowsqlService WorkflowsqlService) : 
            base(logger)
        {
            _WorkflowsqlService = WorkflowsqlService;
        }

        /// <summary>
        /// 查询工作流获取权限系统数据模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Workflowsql> Get(int id)
        {
            // 1、查询工作流获取权限系统数据模型
           return await _WorkflowsqlService.GetAsync(id);
        }

        /// <summary>
        /// 添加工作流获取权限系统数据模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(Workflowsql Workflowsql)
        {
            // 1、添加工作流获取权限系统数据模型
            return await _WorkflowsqlService.AddAsync(Workflowsql);
        }
    }
}