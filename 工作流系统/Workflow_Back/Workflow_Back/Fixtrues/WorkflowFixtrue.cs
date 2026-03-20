using JadeFramework.Dapper.DbContext;
using JadeFramework.Dapper.SqlGenerator;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using Workflow_Back.Contexts;
using Workflow_Back.Repositorise;

namespace Workflow_Back.Fixtrues
{
    /// <summary>
    /// 工作流固定类：实现创建WorkflowDbContext
    /// </summary>
    public class WorkflowFixtrue
    {
        /// <summary>
        /// 工作流配置类
        /// </summary>
        private IConfiguration Configuration;
        public IWorkflowDbContext db { get; }

        public WorkflowFixtrue(IConfiguration configuration)
        {
            Configuration = configuration;

            // 1、创建WorkflowDbContext
            // 1.1、获取连接字符串
            string MySQLAddress = configuration["MySQL:Connection"];
            db = new WorkflowDbContext(MySQLAddress);
        }

    }
}
