using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程分类模型Service接口
    /// </summary>
    public interface IWorkflowCategoryService
    {
        /// <summary>
        /// 获取流程分类模型信息
        /// </summary>
        /// <param name="Id">流程分类模型ID</param>
        /// <returns></returns>
        public Task<WorkflowCategory> GetAsync(int Id);

        /// <summary>
        /// 新增流程分类模型
        /// </summary>
        /// <param name="WorkflowCategory"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(WorkflowCategory WorkflowCategory);
    }
}
