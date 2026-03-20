using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程实例模型【根据流程运行流程】Service接口
    /// </summary>
    public interface IWorkflowInstanceService
    {
        /// <summary>
        /// 获取流程实例模型【根据流程运行流程】信息
        /// </summary>
        /// <param name="Id">流程实例模型【根据流程运行流程】ID</param>
        /// <returns></returns>
        public Task<WorkflowInstance> GetAsync(int Id);

        /// <summary>
        /// 新增流程实例模型【根据流程运行流程】
        /// </summary>
        /// <param name="WorkflowInstance"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowInstance WorkflowInstance);
    }
}
