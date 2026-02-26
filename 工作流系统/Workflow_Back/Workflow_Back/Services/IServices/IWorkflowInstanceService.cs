using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public interface IWorkflowInstanceService
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public Task<WorkflowInstance> GetAsync(int Id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="WorkflowInstance"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowInstance WorkflowInstance);
    }
}
