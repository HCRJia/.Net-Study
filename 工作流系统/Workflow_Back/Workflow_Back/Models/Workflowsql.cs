using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("workflowsql")]
    public class Workflowsql
    {
        /// <summary>
        /// 当前节点ID
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 工作流ID
        /// </summary>
        public string FlowId { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string FlowSQL { get; set; }
        /// <summary>
        /// 流程ID
        /// </summary>
        public string Param { get; set; }
        /// <summary>
        /// 实例编号
        /// </summary>
        public bool SQLType { get; set; }
        /// <summary>
        /// 当前节点类型
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 当前节点名称
        /// </summary>
        public long CreateUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long CreateTime { get; set; }
    }

    /// <summary>
    /// -表映射
    /// </summary>
    public sealed class WorkflowsqlMapper : ClassMapper<Workflowsql>
    {
        public WorkflowsqlMapper()
        {
            // 1、映射到workflowsql
            Table("workflowsql");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}