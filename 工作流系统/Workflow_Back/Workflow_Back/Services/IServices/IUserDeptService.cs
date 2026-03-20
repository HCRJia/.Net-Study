using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 用户部门关联模型Service接口
    /// </summary>
    public interface IUserDeptService
    {
        /// <summary>
        /// 获取用户部门关联模型信息
        /// </summary>
        /// <param name="Id">用户部门关联模型ID</param>
        /// <returns></returns>
        public Task<UserDept> GetAsync(int Id);

        /// <summary>
        /// 新增用户部门关联模型
        /// </summary>
        /// <param name="UserDept"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(UserDept UserDept);
    }
}
