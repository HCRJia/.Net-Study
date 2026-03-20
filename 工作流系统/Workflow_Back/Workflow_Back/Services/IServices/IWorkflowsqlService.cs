using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 工作流获取权限系统数据模型Service接口
    /// </summary>
    public interface IWorkflowsqlService
    {
        /// <summary>
        /// 获取工作流获取权限系统数据模型信息
        /// </summary>
        /// <param name="Id">工作流获取权限系统数据模型ID</param>
        /// <returns></returns>
        public Task<Workflowsql> GetAsync(int Id);

        /// <summary>
        /// 新增工作流获取权限系统数据模型
        /// </summary>
        /// <param name="Workflowsql"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(Workflowsql Workflowsql);
    }
}
