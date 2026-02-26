using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public interface IWorkflowUrgeService
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public Task<WorkflowUrge> GetAsync(int Id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="WorkflowUrge"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowUrge WorkflowUrge);
    }
}
