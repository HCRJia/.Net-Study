using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 子系统模型Service接口
    /// </summary>
    public class SystemsService : ISystemsService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public SystemsService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<Systems> GetAsync(int Id)
        {
            //1、查询子系统模型数据
            return await _workflowFixtrue.db.Systemss.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(Systems Systems)
        {
            return await _workflowFixtrue.db.Systemss.InsertAsync(Systems);
        }
    }
}