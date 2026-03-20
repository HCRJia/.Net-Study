using JadeFramework.Dapper;
using JadeFramework.Dapper.SqlGenerator;
using System.Data;
using Workflow_Back.Models;

namespace Workflow_Back.Repositorise
{
    /// <summary>
    /// 角色资源关联模型仓储实现
    /// </summary>
    public class RoleResourceRepository : DapperRepository<RoleResource>, IRoleResourceRepository
    {
        /// <summary>
        /// 1、IDbConnection : Dapper实现数据库操作，连接对象
        /// 2、SqlGeneratorConfig ：配置数据库类型。MySQL SqlServer Oracle
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="config"></param>
        public RoleResourceRepository(IDbConnection connection, 
            SqlGeneratorConfig config) : base(connection, config)
        {
        }
    }
}
