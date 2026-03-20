using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 角色资源关联模型Service接口
    /// </summary>
    public interface IRoleResourceService
    {
        /// <summary>
        /// 获取角色资源关联模型信息
        /// </summary>
        /// <param name="Id">角色资源关联模型ID</param>
        /// <returns></returns>
        public Task<RoleResource> GetAsync(int Id);

        /// <summary>
        /// 新增角色资源关联模型
        /// </summary>
        /// <param name="RoleResource"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(RoleResource RoleResource);
    }
}
