using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 流程通知节点模型
    /// </summary>
    [Table("ydt_workflow_notice")]
    public class WorkflowNotice
    {   
public string NoticeId { get; set; }
public string InstanceId { get; set; }
public string NodeId { get; set; }
public string NodeName { get; set; }
public string Maker { get; set; }
public bool IsTransition { get; set; }
public bool Status { get; set; }
public bool IsRead { get; set; }
}

    /// <summary>
    /// 流程通知节点模型-流程通知节点模型表映射
    /// </summary>
    public sealed class WorkflowNoticeMapper : ClassMapper<WorkflowNotice>
    {
        public WorkflowNoticeMapper()
        {
            // 1、映射到ydt_workflow_notice
            Table("ydt_workflow_notice");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}