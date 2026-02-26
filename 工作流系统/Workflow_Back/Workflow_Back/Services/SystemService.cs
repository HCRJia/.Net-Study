using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public class SystemService : ISystemService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public SystemService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<Systems> GetAsync(int Id)
        {
            //1、查询数据
            return await _workflowFixtrue.db._SystemRepository.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(Systems System)
        {
            return await _workflowFixtrue.db._SystemRepository.InsertAsync(System);
        }
    }
}