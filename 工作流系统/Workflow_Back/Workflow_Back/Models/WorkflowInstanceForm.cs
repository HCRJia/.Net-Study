using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 流程实例表单关联模型
    /// </summary>
    [Table("ydt_workflow_instance_form")]
    public class WorkflowInstanceForm
    {   
public string InstanceFormId { get; set; }
public string InstanceId { get; set; }
public string FormId { get; set; }
public string FlowContent { get; set; }
public int FormType { get; set; }
public string FormUrl { get; set; }
public string FormData { get; set; }
}

    /// <summary>
    /// 流程实例表单关联模型-流程实例表单关联模型表映射
    /// </summary>
    public sealed class WorkflowInstanceFormMapper : ClassMapper<WorkflowInstanceForm>
    {
        public WorkflowInstanceFormMapper()
        {
            // 1、映射到ydt_workflow_instance_form
            Table("ydt_workflow_instance_form");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}