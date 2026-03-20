using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程通知节点模型Service接口
    /// </summary>
    public class WorkflowNoticeService : IWorkflowNoticeService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowNoticeService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<WorkflowNotice> GetAsync(int Id)
        {
            //1、查询流程通知节点模型数据
            return await _workflowFixtrue.db.WorkflowNotices.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(WorkflowNotice WorkflowNotice)
        {
            return await _workflowFixtrue.db.WorkflowNotices.InsertAsync(WorkflowNotice);
        }
    }
}