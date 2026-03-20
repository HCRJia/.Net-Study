using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程通知节点模型Service接口
    /// </summary>
    public interface IWorkflowNoticeService
    {
        /// <summary>
        /// 获取流程通知节点模型信息
        /// </summary>
        /// <param name="Id">流程通知节点模型ID</param>
        /// <returns></returns>
        public Task<WorkflowNotice> GetAsync(int Id);

        /// <summary>
        /// 新增流程通知节点模型
        /// </summary>
        /// <param name="WorkflowNotice"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowNotice WorkflowNotice);
    }
}
