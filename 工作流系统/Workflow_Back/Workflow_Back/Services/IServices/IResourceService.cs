using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public interface IResourceService
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public Task<Resource> GetAsync(int Id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="Resource"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(Resource Resource);
    }
}
