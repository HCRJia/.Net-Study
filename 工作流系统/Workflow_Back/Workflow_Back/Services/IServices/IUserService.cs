using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public Task<User> GetAsync(int Id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(User User);
    }
}
