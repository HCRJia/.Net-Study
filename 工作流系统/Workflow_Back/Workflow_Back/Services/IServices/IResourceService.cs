using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 资源【菜单】模型Service接口
    /// </summary>
    public interface IResourceService
    {
        /// <summary>
        /// 获取资源【菜单】模型信息
        /// </summary>
        /// <param name="Id">资源【菜单】模型ID</param>
        /// <returns></returns>
        public Task<Resource> GetAsync(int Id);

        /// <summary>
        /// 新增资源【菜单】模型
        /// </summary>
        /// <param name="Resource"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(Resource Resource);
    }
}
