using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 工作流模型
    /// </summary>
    [Table("ydt_workflow")]
    public class Workflow
    {   
public string FlowId { get; set; }
public string FlowCode { get; set; }
public string CategoryId { get; set; }
public string FormId { get; set; }
public string FlowName { get; set; }
public string FlowContent { get; set; }
public int FlowVersion { get; set; }
public string Memo { get; set; }
public int Enable { get; set; }
public int IsOld { get; set; }
}

    /// <summary>
    /// 工作流模型-工作流模型表映射
    /// </summary>
    public sealed class WorkflowMapper : ClassMapper<Workflow>
    {
        public WorkflowMapper()
        {
            // 1、映射到ydt_workflow
            Table("ydt_workflow");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}