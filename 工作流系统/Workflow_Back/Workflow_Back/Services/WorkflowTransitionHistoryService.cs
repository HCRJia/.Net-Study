using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程流转历史模型Service接口
    /// </summary>
    public class WorkflowTransitionHistoryService : IWorkflowTransitionHistoryService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowTransitionHistoryService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<WorkflowTransitionHistory> GetAsync(int Id)
        {
            //1、查询流程流转历史模型数据
            return await _workflowFixtrue.db.WorkflowTransitionHistorys.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(WorkflowTransitionHistory WorkflowTransitionHistory)
        {
            return await _workflowFixtrue.db.WorkflowTransitionHistorys.InsertAsync(WorkflowTransitionHistory);
        }
    }
}