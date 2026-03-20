using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 催办记录模型
    /// </summary>
    [Table("ydt_workflow_urge")]
    public class WorkflowUrge
    {   
public string UrgeId { get; set; }
public string InstanceId { get; set; }
public string NodeId { get; set; }
public string NodeName { get; set; }
public string Sender { get; set; }
public string UrgeUser { get; set; }
public int UrgeType { get; set; }
public string UrgeContent { get; set; }
}

    /// <summary>
    /// 催办记录模型-催办记录模型表映射
    /// </summary>
    public sealed class WorkflowUrgeMapper : ClassMapper<WorkflowUrge>
    {
        public WorkflowUrgeMapper()
        {
            // 1、映射到ydt_workflow_urge
            Table("ydt_workflow_urge");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}