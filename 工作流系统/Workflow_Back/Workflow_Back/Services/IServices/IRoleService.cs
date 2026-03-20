using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 角色模型Service接口
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 获取角色模型信息
        /// </summary>
        /// <param name="Id">角色模型ID</param>
        /// <returns></returns>
        public Task<Role> GetAsync(int Id);

        /// <summary>
        /// 新增角色模型
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(Role Role);
    }
}
