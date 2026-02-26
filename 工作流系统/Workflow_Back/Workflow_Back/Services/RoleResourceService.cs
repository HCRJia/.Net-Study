using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public class RoleResourceService : IRoleResourceService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public RoleResourceService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<RoleResource> GetAsync(int Id)
        {
            //1、查询数据
            return await _workflowFixtrue.db._RoleResourceRepository.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(RoleResource RoleResource)
        {
            return await _workflowFixtrue.db._RoleResourceRepository.InsertAsync(RoleResource);
        }
    }
}