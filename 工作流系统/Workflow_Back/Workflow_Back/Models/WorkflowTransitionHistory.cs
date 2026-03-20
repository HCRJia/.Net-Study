using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 流程流转历史模型
    /// </summary>
    [Table("ydt_workflow_transition_history")]
    public class WorkflowTransitionHistory
    {   
public string TransitionId { get; set; }
public string InstanceId { get; set; }
public string FromNodeId { get; set; }
public int FromNodeType { get; set; }
public string FromNodName { get; set; }
public string ToNodeId { get; set; }
public int ToNodeType { get; set; }
public string ToNodeName { get; set; }
public int TransitionState { get; set; }
public int IsFinish { get; set; }
public string CreateUserName { get; set; }
}

    /// <summary>
    /// 流程流转历史模型-流程流转历史模型表映射
    /// </summary>
    public sealed class WorkflowTransitionHistoryMapper : ClassMapper<WorkflowTransitionHistory>
    {
        public WorkflowTransitionHistoryMapper()
        {
            // 1、映射到ydt_workflow_transition_history
            Table("ydt_workflow_transition_history");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}