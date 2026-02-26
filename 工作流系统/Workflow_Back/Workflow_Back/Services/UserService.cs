using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public UserService(WorkflowFixtrue workflowFixtrue)
        {
            _workflowFixtrue = workflowFixtrue;
        }

        public async Task<User> GetAsync(int Id)
        {
            //1、查询数据
            return await _workflowFixtrue.db._UserRepository.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(User User)
        {
            return await _workflowFixtrue.db._UserRepository.InsertAsync(User);
        }
    }
}