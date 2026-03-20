using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 催办记录模型Service接口
    /// </summary>
    public class WorkflowUrgeService : IWorkflowUrgeService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowUrgeService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<WorkflowUrge> GetAsync(int Id)
        {
            //1、查询催办记录模型数据
            return await _workflowFixtrue.db.WorkflowUrges.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(WorkflowUrge WorkflowUrge)
        {
            return await _workflowFixtrue.db.WorkflowUrges.InsertAsync(WorkflowUrge);
        }
    }
}