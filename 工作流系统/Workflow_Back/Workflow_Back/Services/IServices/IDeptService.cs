using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 部门模型Service接口
    /// </summary>
    public interface IDeptService
    {
        /// <summary>
        /// 获取部门模型信息
        /// </summary>
        /// <param name="Id">部门模型ID</param>
        /// <returns></returns>
        public Task<Dept> GetAsync(int Id);

        /// <summary>
        /// 新增部门模型
        /// </summary>
        /// <param name="Dept"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(Dept Dept);
    }
}
