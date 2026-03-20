using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 流程分类模型
    /// </summary>
    [Table("ydt_workflow_category")]
    public class WorkflowCategory
    {   
public string CategoryId { get; set; }
public string Name { get; set; }
public string ParentId { get; set; }
public string Memo { get; set; }
public int Status { get; set; }
}

    /// <summary>
    /// 流程分类模型-流程分类模型表映射
    /// </summary>
    public sealed class WorkflowCategoryMapper : ClassMapper<WorkflowCategory>
    {
        public WorkflowCategoryMapper()
        {
            // 1、映射到ydt_workflow_category
            Table("ydt_workflow_category");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}