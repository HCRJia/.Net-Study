using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 流程实例表单关联模型Service接口
    /// </summary>
    public class WorkflowInstanceFormService : IWorkflowInstanceFormService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public WorkflowInstanceFormService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<WorkflowInstanceForm> GetAsync(int Id)
        {
            //1、查询流程实例表单关联模型数据
            return await _workflowFixtrue.db.WorkflowInstanceForms.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(WorkflowInstanceForm WorkflowInstanceForm)
        {
            return await _workflowFixtrue.db.WorkflowInstanceForms.InsertAsync(WorkflowInstanceForm);
        }
    }
}