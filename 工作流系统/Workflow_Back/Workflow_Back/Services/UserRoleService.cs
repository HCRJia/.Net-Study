using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public class UserRoleService : IUserRoleService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public UserRoleService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<UserRole> GetAsync(int Id)
        {
            //1、查询数据
            return await _workflowFixtrue.db._UserRoleRepository.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(UserRole UserRole)
        {
            return await _workflowFixtrue.db._UserRoleRepository.InsertAsync(UserRole);
        }
    }
}