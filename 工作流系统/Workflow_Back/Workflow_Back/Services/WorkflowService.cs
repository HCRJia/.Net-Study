using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 工作流模型Service接口
    /// </summary>
    public class WorkflowService : IWorkflowService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<Workflow> GetAsync(int Id)
        {
            //1、查询工作流模型数据
            return await _workflowFixtrue.db.Workflows.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(Workflow Workflow)
        {
            return await _workflowFixtrue.db.Workflows.InsertAsync(Workflow);
        }
    }
}