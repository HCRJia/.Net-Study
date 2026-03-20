using JadeFramework.Dapper;
using Workflow_Back.Models;

namespace Workflow_Back.Repositorise
{
    /// <summary>
    /// 流程实例模型【根据流程运行流程】仓储接口
    /// </summary>
    public interface IWorkflowInstanceRepository : IDapperRepository<WorkflowInstance>
    {

    }
}
