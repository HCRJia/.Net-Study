using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public class WorkflowCategoryService : IWorkflowCategoryService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowCategoryService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<WorkflowCategory> GetAsync(int Id)
        {
            //1、查询数据
            return await _workflowFixtrue.db._WorkflowCategoryRepository.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(WorkflowCategory WorkflowCategory)
        {
            return await _workflowFixtrue.db._WorkflowCategoryRepository.InsertAsync(WorkflowCategory);
        }
    }
}