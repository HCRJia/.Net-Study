using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Service
{
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
            //1、查询用户数据
            return await _workflowFixtrue.db.userRepository.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(User user)
        {
            return await _workflowFixtrue.db.userRepository.InsertAsync(user);
        }
    }
}
