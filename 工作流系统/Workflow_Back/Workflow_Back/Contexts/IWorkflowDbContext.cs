using JadeFramework.Dapper.DbContext;
using Workflow_Back.Repositorys;

namespace Workflow_Back.Contexts
{
    /// <summary>
    /// 工作流上下文接口
    /// </summary>
    public interface IWorkflowDbContext : IDapperDbContext
    {
         //依赖IDeptRepository
         public IDeptRepository _DeptRepository { get; }
         //依赖IResourceRepository
         public IResourceRepository _ResourceRepository { get; }
         //依赖IRoleRepository
         public IRoleRepository _RoleRepository { get; }
         //依赖IRoleResourceRepository
         public IRoleResourceRepository _RoleResourceRepository { get; }
         //依赖ISystemRepository
         public ISystemRepository _SystemRepository { get; }
         //依赖IUserRepository
         public IUserRepository _UserRepository { get; }
         //依赖IUserDeptRepository
         public IUserDeptRepository _UserDeptRepository { get; }
         //依赖IUserRoleRepository
         public IUserRoleRepository _UserRoleRepository { get; }
         //依赖IWorkflowRepository
         public IWorkflowRepository _WorkflowRepository { get; }
         //依赖IWorkflowAssignRepository
         public IWorkflowAssignRepository _WorkflowAssignRepository { get; }
         //依赖IWorkflowCategoryRepository
         public IWorkflowCategoryRepository _WorkflowCategoryRepository { get; }
         //依赖IWorkflowFormRepository
         public IWorkflowFormRepository _WorkflowFormRepository { get; }
         //依赖IWorkflowInstanceRepository
         public IWorkflowInstanceRepository _WorkflowInstanceRepository { get; }
         //依赖IWorkflowInstanceFormRepository
         public IWorkflowInstanceFormRepository _WorkflowInstanceFormRepository { get; }
         //依赖IWorkflowNoticeRepository
         public IWorkflowNoticeRepository _WorkflowNoticeRepository { get; }
         //依赖IWorkflowOperationHistoryRepository
         public IWorkflowOperationHistoryRepository _WorkflowOperationHistoryRepository { get; }
         //依赖IWorkflowTransitionHistoryRepository
         public IWorkflowTransitionHistoryRepository _WorkflowTransitionHistoryRepository { get; }
         //依赖IWorkflowUrgeRepository
         public IWorkflowUrgeRepository _WorkflowUrgeRepository { get; }
         //依赖IWorkflowsqlRepository
         public IWorkflowsqlRepository _WorkflowsqlRepository { get; }
    }
}
