using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("workflow_urge")]
    public class WorkflowUrge
    {
        /// <summary>
        /// 当前节点ID
        /// </summary>
        [Key,Identity]
        public string Id { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string InstanceId { get; set; }
        /// <summary>
        /// 流程ID
        /// </summary>
        public string NodeId { get; set; }
        /// <summary>
        /// 实例编号
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 当前节点类型
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UrgeUser { get; set; }
        /// <summary>
        /// 当前节点名称
        /// </summary>
        public int UrgeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UrgeContent { get; set; }
    }

    /// <summary>
    /// -表映射
    /// </summary>
    public sealed class WorkflowUrgeMapper : ClassMapper<WorkflowUrge>
    {
        public WorkflowUrgeMapper()
        {
            // 1、映射到workflow_urge
            Table("workflow_urge");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}