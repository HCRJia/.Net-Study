using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程操作历史模型Service接口
    /// </summary>
    public interface IWorkflowOperationHistoryService
    {
        /// <summary>
        /// 获取流程操作历史模型信息
        /// </summary>
        /// <param name="Id">流程操作历史模型ID</param>
        /// <returns></returns>
        public Task<WorkflowOperationHistory> GetAsync(int Id);

        /// <summary>
        /// 新增流程操作历史模型
        /// </summary>
        /// <param name="WorkflowOperationHistory"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowOperationHistory WorkflowOperationHistory);
    }
}
