using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public class WorkflowOperationHistoryService : IWorkflowOperationHistoryService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowOperationHistoryService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<WorkflowOperationHistory> GetAsync(int Id)
        {
            //1、查询数据
            return await _workflowFixtrue.db._WorkflowOperationHistoryRepository.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(WorkflowOperationHistory WorkflowOperationHistory)
        {
            return await _workflowFixtrue.db._WorkflowOperationHistoryRepository.InsertAsync(WorkflowOperationHistory);
        }
    }
}