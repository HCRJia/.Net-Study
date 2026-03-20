using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 工作流获取权限系统数据模型
    /// </summary>
    [Table("ydt_workflowsql")]
    public class Workflowsql
    {   
public string Name { get; set; }
public string FlowId { get; set; }
public string FlowSQL { get; set; }
public string Param { get; set; }
public bool SQLType { get; set; }
public int Status { get; set; }
public string Remark { get; set; }
public long CreateUserId { get; set; }
public long CreateTime { get; set; }
}

    /// <summary>
    /// 工作流获取权限系统数据模型-工作流获取权限系统数据模型表映射
    /// </summary>
    public sealed class WorkflowsqlMapper : ClassMapper<Workflowsql>
    {
        public WorkflowsqlMapper()
        {
            // 1、映射到ydt_workflowsql
            Table("ydt_workflowsql");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}