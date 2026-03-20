using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程实例表单关联模型Service接口
    /// </summary>
    public interface IWorkflowInstanceFormService
    {
        /// <summary>
        /// 获取流程实例表单关联模型信息
        /// </summary>
        /// <param name="Id">流程实例表单关联模型ID</param>
        /// <returns></returns>
        public Task<WorkflowInstanceForm> GetAsync(int Id);

        /// <summary>
        /// 新增流程实例表单关联模型
        /// </summary>
        /// <param name="WorkflowInstanceForm"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowInstanceForm WorkflowInstanceForm);
    }
}
