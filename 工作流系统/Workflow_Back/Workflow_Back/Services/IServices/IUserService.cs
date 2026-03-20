using Workflow_Back.Dtos;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 用户模型Service接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 获取用户模型信息
        /// </summary>
        /// <param name="Id">用户模型ID</param>
        /// <returns></returns>
        public Task<User> GetAsync(int Id);

        /// <summary>
        /// 新增用户模型
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(User User);

        /// <summary>
        /// 创建用户服务
        /// </summary>
        /// <param name="userCreateDto"></param>
        /// <returns></returns>
        public Task<bool> UserCreateAsync(UserCreateDto userCreateDto);
    }
}
