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
    public class WorkflowUrgeController : CommonController<WorkflowUrgeController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IWorkflowUrgeService _WorkflowUrgeService;   

        public WorkflowUrgeController(ILogger<WorkflowUrgeController> logger,
                                IWorkflowUrgeService WorkflowUrgeService) : 
            base(logger)
        {
            _WorkflowUrgeService = WorkflowUrgeService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowUrge> Get(int id)
        {
            // 1、查询
           return await _WorkflowUrgeService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowUrge WorkflowUrge)
        {
            // 1、添加
            return await _WorkflowUrgeService.AddAsync(WorkflowUrge);
        }
    }
}