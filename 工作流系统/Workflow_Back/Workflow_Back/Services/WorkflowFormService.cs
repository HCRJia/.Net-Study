using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程表单模型Service接口
    /// </summary>
    public class WorkflowFormService : IWorkflowFormService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowFormService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<WorkflowForm> GetAsync(int Id)
        {
            //1、查询流程表单模型数据
            return await _workflowFixtrue.db.WorkflowForms.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(WorkflowForm WorkflowForm)
        {
            return await _workflowFixtrue.db.WorkflowForms.InsertAsync(WorkflowForm);
        }
    }
}