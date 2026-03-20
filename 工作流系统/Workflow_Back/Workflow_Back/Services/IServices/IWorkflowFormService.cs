using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程表单模型Service接口
    /// </summary>
    public interface IWorkflowFormService
    {
        /// <summary>
        /// 获取流程表单模型信息
        /// </summary>
        /// <param name="Id">流程表单模型ID</param>
        /// <returns></returns>
        public Task<WorkflowForm> GetAsync(int Id);

        /// <summary>
        /// 新增流程表单模型
        /// </summary>
        /// <param name="WorkflowForm"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowForm WorkflowForm);
    }
}
