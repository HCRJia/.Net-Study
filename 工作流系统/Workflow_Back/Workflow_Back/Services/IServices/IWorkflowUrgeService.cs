using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 催办记录模型Service接口
    /// </summary>
    public interface IWorkflowUrgeService
    {
        /// <summary>
        /// 获取催办记录模型信息
        /// </summary>
        /// <param name="Id">催办记录模型ID</param>
        /// <returns></returns>
        public Task<WorkflowUrge> GetAsync(int Id);

        /// <summary>
        /// 新增催办记录模型
        /// </summary>
        /// <param name="WorkflowUrge"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowUrge WorkflowUrge);
    }
}
