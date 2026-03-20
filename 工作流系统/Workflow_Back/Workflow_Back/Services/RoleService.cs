using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 角色模型Service接口
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public RoleService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<Role> GetAsync(int Id)
        {
            //1、查询角色模型数据
            return await _workflowFixtrue.db.Roles.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(Role Role)
        {
            return await _workflowFixtrue.db.Roles.InsertAsync(Role);
        }
    }
}