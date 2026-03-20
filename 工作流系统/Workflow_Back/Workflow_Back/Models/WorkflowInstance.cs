using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 流程实例模型【根据流程运行流程】
    /// </summary>
    [Table("ydt_workflow_instance")]
    public class WorkflowInstance
    {   
public string InstanceId { get; set; }
public string FlowId { get; set; }
public string Code { get; set; }
public string ActivityId { get; set; }
public int ActivityType { get; set; }
public string ActivityName { get; set; }
public string PreviousId { get; set; }
public string MakerList { get; set; }
public string FlowContent { get; set; }
public int FlowVersion { get; set; }
public string CreateUserName { get; set; }
public long UpdateTime { get; set; }
}

    /// <summary>
    /// 流程实例模型【根据流程运行流程】-流程实例模型【根据流程运行流程】表映射
    /// </summary>
    public sealed class WorkflowInstanceMapper : ClassMapper<WorkflowInstance>
    {
        public WorkflowInstanceMapper()
        {
            // 1、映射到ydt_workflow_instance
            Table("ydt_workflow_instance");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}