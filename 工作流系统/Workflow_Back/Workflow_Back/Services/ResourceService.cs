using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 资源【菜单】模型Service接口
    /// </summary>
    public class ResourceService : IResourceService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public ResourceService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<Resource> GetAsync(int Id)
        {
            //1、查询资源【菜单】模型数据
            return await _workflowFixtrue.db.Resources.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(Resource Resource)
        {
            return await _workflowFixtrue.db.Resources.InsertAsync(Resource);
        }
    }
}