using JadeFramework.Dapper;
using Workflow_Back.Models;

namespace Workflow_Back.Repositorise
{
    /// <summary>
    /// 用户模型仓储接口
    /// </summary>
    public interface IUserRepository : IDapperRepository<User>
    {

    }
}
