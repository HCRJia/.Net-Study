using JadeFramework.Dapper.DbContext;
using JadeFramework.Dapper.SqlGenerator;
using MySql.Data.MySqlClient;
using Workflow_Back.Repositorise;

namespace Workflow_Back.Contexts
{
    public class WorkflowDbContext : DapperDbContext, IWorkflowDbContext
    {
        /// <summary>
        /// 1、数据库选择配置
        /// </summary>
        private readonly SqlGeneratorConfig sqlGeneratorConfig = new SqlGeneratorConfig
        {
            SqlConnector = ESqlConnector.MySQL, // 使用MySQL
            UseQuotationMarks = true // 表和列名使用引号
        };

        public WorkflowDbContext(string ConnectionString) :
            base(new MySqlConnection(ConnectionString))
        {
        }

        /// <summary>
        /// 实现用户仓储
        /// </summary>
        public IUserRepository userRepository => new UserRepository(Connection, sqlGeneratorConfig);

        public IRoleRepository roleRepository => new RoleRepository(Connection, sqlGeneratorConfig);

    }
}
