using Workflow_Back.Models;

namespace Workflow_Back.Service
{
    /// <summary>
    /// 用户Service接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="roleid">角色ID</param>
        /// <returns></returns>
        public Task<User> GetAsync(int Id);

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(User user);
    }
}
