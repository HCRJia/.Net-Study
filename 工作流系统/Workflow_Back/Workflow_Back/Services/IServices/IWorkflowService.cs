using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 工作流模型Service接口
    /// </summary>
    public interface IWorkflowService
    {
        /// <summary>
        /// 获取工作流模型信息
        /// </summary>
        /// <param name="Id">工作流模型ID</param>
        /// <returns></returns>
        public Task<Workflow> GetAsync(int Id);

        /// <summary>
        /// 新增工作流模型
        /// </summary>
        /// <param name="Workflow"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(Workflow Workflow);
    }
}
