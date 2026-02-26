using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public interface IUserDeptService
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public Task<UserDept> GetAsync(int Id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="UserDept"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(UserDept UserDept);
    }
}
