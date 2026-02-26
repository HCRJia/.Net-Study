using JadeFramework.Dapper.DbContext;
using JadeFramework.Dapper.SqlGenerator;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using Workflow_Back.Repositorys;

namespace Workflow_Back.Contexts
{
    /// <summary>
    /// 工作流上下文实现
    /// </summary>
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
         //实现IDeptRepository
         public IDeptRepository _DeptRepository => new DeptRepository(Connection, sqlGeneratorConfig);
         //实现IResourceRepository
         public IResourceRepository _ResourceRepository => new ResourceRepository(Connection, sqlGeneratorConfig);
         //实现IRoleRepository
         public IRoleRepository _RoleRepository => new RoleRepository(Connection, sqlGeneratorConfig);
         //实现IRoleResourceRepository
         public IRoleResourceRepository _RoleResourceRepository => new RoleResourceRepository(Connection, sqlGeneratorConfig);
         //实现ISystemRepository
         public ISystemRepository _SystemRepository => new SystemRepository(Connection, sqlGeneratorConfig);
         //实现IUserRepository
         public IUserRepository _UserRepository => new UserRepository(Connection, sqlGeneratorConfig);
         //实现IUserDeptRepository
         public IUserDeptRepository _UserDeptRepository => new UserDeptRepository(Connection, sqlGeneratorConfig);
         //实现IUserRoleRepository
         public IUserRoleRepository _UserRoleRepository => new UserRoleRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowRepository
         public IWorkflowRepository _WorkflowRepository => new WorkflowRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowAssignRepository
         public IWorkflowAssignRepository _WorkflowAssignRepository => new WorkflowAssignRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowCategoryRepository
         public IWorkflowCategoryRepository _WorkflowCategoryRepository => new WorkflowCategoryRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowFormRepository
         public IWorkflowFormRepository _WorkflowFormRepository => new WorkflowFormRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowInstanceRepository
         public IWorkflowInstanceRepository _WorkflowInstanceRepository => new WorkflowInstanceRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowInstanceFormRepository
         public IWorkflowInstanceFormRepository _WorkflowInstanceFormRepository => new WorkflowInstanceFormRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowNoticeRepository
         public IWorkflowNoticeRepository _WorkflowNoticeRepository => new WorkflowNoticeRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowOperationHistoryRepository
         public IWorkflowOperationHistoryRepository _WorkflowOperationHistoryRepository => new WorkflowOperationHistoryRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowTransitionHistoryRepository
         public IWorkflowTransitionHistoryRepository _WorkflowTransitionHistoryRepository => new WorkflowTransitionHistoryRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowUrgeRepository
         public IWorkflowUrgeRepository _WorkflowUrgeRepository => new WorkflowUrgeRepository(Connection, sqlGeneratorConfig);
         //实现IWorkflowsqlRepository
         public IWorkflowsqlRepository _WorkflowsqlRepository => new WorkflowsqlRepository(Connection, sqlGeneratorConfig);
    }
}
