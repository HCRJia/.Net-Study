using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public interface IWorkflowTransitionHistoryService
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public Task<WorkflowTransitionHistory> GetAsync(int Id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="WorkflowTransitionHistory"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowTransitionHistory WorkflowTransitionHistory);
    }
}
