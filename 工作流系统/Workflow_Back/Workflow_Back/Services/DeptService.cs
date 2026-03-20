using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 部门模型Service接口
    /// </summary>
    public class DeptService : IDeptService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public DeptService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<Dept> GetAsync(int Id)
        {
            //1、查询部门模型数据
            return await _workflowFixtrue.db.Depts.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(Dept Dept)
        {
            return await _workflowFixtrue.db.Depts.InsertAsync(Dept);
        }
    }
}