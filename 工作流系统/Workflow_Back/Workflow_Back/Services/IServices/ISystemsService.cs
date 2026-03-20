using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 子系统模型Service接口
    /// </summary>
    public interface ISystemsService
    {
        /// <summary>
        /// 获取子系统模型信息
        /// </summary>
        /// <param name="Id">子系统模型ID</param>
        /// <returns></returns>
        public Task<Systems> GetAsync(int Id);

        /// <summary>
        /// 新增子系统模型
        /// </summary>
        /// <param name="Systems"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(Systems Systems);
    }
}
