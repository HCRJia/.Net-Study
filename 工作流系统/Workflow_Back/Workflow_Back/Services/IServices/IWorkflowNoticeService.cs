using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public interface IWorkflowNoticeService
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public Task<WorkflowNotice> GetAsync(int Id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="WorkflowNotice"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowNotice WorkflowNotice);
    }
}
