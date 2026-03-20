using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 用户角色关联模型Service接口
    /// </summary>
    public interface IUserRoleService
    {
        /// <summary>
        /// 获取用户角色关联模型信息
        /// </summary>
        /// <param name="Id">用户角色关联模型ID</param>
        /// <returns></returns>
        public Task<UserRole> GetAsync(int Id);

        /// <summary>
        /// 新增用户角色关联模型
        /// </summary>
        /// <param name="UserRole"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(UserRole UserRole);
    }
}
