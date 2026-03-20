using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 流程操作历史模型
    /// </summary>
    [Table("ydt_workflow_operation_history")]
    public class WorkflowOperationHistory
    {   
public string OperationId { get; set; }
public string InstanceId { get; set; }
public string NodeId { get; set; }
public string NodeName { get; set; }
public int TransitionType { get; set; }
public string Content { get; set; }
public string CreateUserName { get; set; }
}

    /// <summary>
    /// 流程操作历史模型-流程操作历史模型表映射
    /// </summary>
    public sealed class WorkflowOperationHistoryMapper : ClassMapper<WorkflowOperationHistory>
    {
        public WorkflowOperationHistoryMapper()
        {
            // 1、映射到ydt_workflow_operation_history
            Table("ydt_workflow_operation_history");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}