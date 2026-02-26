using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public class WorkflowAssignService : IWorkflowAssignService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowAssignService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<WorkflowAssign> GetAsync(int Id)
        {
            //1、查询数据
            return await _workflowFixtrue.db._WorkflowAssignRepository.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(WorkflowAssign WorkflowAssign)
        {
            return await _workflowFixtrue.db._WorkflowAssignRepository.InsertAsync(WorkflowAssign);
        }
    }
}