using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程委托模型Service接口
    /// </summary>
    public interface IWorkflowAssignService
    {
        /// <summary>
        /// 获取流程委托模型信息
        /// </summary>
        /// <param name="Id">流程委托模型ID</param>
        /// <returns></returns>
        public Task<WorkflowAssign> GetAsync(int Id);

        /// <summary>
        /// 新增流程委托模型
        /// </summary>
        /// <param name="WorkflowAssign"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowAssign WorkflowAssign);
    }
}
