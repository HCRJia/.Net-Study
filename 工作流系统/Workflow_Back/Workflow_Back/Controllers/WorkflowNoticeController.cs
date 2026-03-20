using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 流程通知节点模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkflowNoticeController : CommonController<WorkflowNoticeController>
    {
        /// <summary>
        /// 流程通知节点模型Service
        /// </summary>
        private IWorkflowNoticeService _WorkflowNoticeService;   

        public WorkflowNoticeController(ILogger<WorkflowNoticeController> logger,
                                IWorkflowNoticeService WorkflowNoticeService) : 
            base(logger)
        {
            _WorkflowNoticeService = WorkflowNoticeService;
        }

        /// <summary>
        /// 查询流程通知节点模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<WorkflowNotice> Get(int id)
        {
            // 1、查询流程通知节点模型
           return await _WorkflowNoticeService.GetAsync(id);
        }

        /// <summary>
        /// 添加流程通知节点模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(WorkflowNotice WorkflowNotice)
        {
            // 1、添加流程通知节点模型
            return await _WorkflowNoticeService.AddAsync(WorkflowNotice);
        }
    }
}