using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 流程表单模型
    /// </summary>
    [Table("ydt_workflow_form")]
    public class WorkflowForm
    {   
public string FormId { get; set; }
public string FormName { get; set; }
public int FormType { get; set; }
public string Content { get; set; }
public string OriginalContent { get; set; }
public string FormUrl { get; set; }
}

    /// <summary>
    /// 流程表单模型-流程表单模型表映射
    /// </summary>
    public sealed class WorkflowFormMapper : ClassMapper<WorkflowForm>
    {
        public WorkflowFormMapper()
        {
            // 1、映射到ydt_workflow_form
            Table("ydt_workflow_form");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}