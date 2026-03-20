using JadeFramework.Dapper;
using Workflow_Back.Models;

namespace Workflow_Back.Repositorise
{
    /// <summary>
    /// 流程操作历史模型仓储接口
    /// </summary>
    public interface IWorkflowOperationHistoryRepository : IDapperRepository<WorkflowOperationHistory>
    {

    }
}
