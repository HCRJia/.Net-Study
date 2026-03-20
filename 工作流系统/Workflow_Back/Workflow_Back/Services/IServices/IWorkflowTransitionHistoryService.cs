using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程流转历史模型Service接口
    /// </summary>
    public interface IWorkflowTransitionHistoryService
    {
        /// <summary>
        /// 获取流程流转历史模型信息
        /// </summary>
        /// <param name="Id">流程流转历史模型ID</param>
        /// <returns></returns>
        public Task<WorkflowTransitionHistory> GetAsync(int Id);

        /// <summary>
        /// 新增流程流转历史模型
        /// </summary>
        /// <param name="WorkflowTransitionHistory"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowTransitionHistory WorkflowTransitionHistory);
    }
}
