using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程实例模型【根据流程运行流程】Service接口
    /// </summary>
    public class WorkflowInstanceService : IWorkflowInstanceService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowInstanceService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<WorkflowInstance> GetAsync(int Id)
        {
            //1、查询流程实例模型【根据流程运行流程】数据
            return await _workflowFixtrue.db.WorkflowInstances.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(WorkflowInstance WorkflowInstance)
        {
            return await _workflowFixtrue.db.WorkflowInstances.InsertAsync(WorkflowInstance);
        }
    }
}