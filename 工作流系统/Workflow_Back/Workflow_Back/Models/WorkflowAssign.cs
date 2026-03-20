using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 流程委托模型
    /// </summary>
    [Table("ydt_workflow_assign")]
    public class WorkflowAssign
    {   
public string AssignId { get; set; }
public string FlowId { get; set; }
public string InstanceId { get; set; }
public string NodeId { get; set; }
public string NodeName { get; set; }
public string UserId { get; set; }
public string UserName { get; set; }
public string AssignUserId { get; set; }
public string AssignUserName { get; set; }
public string Content { get; set; }
}

    /// <summary>
    /// 流程委托模型-流程委托模型表映射
    /// </summary>
    public sealed class WorkflowAssignMapper : ClassMapper<WorkflowAssign>
    {
        public WorkflowAssignMapper()
        {
            // 1、映射到ydt_workflow_assign
            Table("ydt_workflow_assign");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}