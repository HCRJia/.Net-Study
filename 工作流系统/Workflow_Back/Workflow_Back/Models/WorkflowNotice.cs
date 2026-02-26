using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("workflow_notice")]
    public class WorkflowNotice
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
        public string Maker { get; set; }
        /// <summary>
        /// 当前节点名称
        /// </summary>
        public bool IsTransition { get; set; }
        /// <summary>
        /// 上一个节点ID
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 执行人为0表示全部人员
        /// </summary>
        public bool IsRead { get; set; }
    }

    /// <summary>
    /// -表映射
    /// </summary>
    public sealed class WorkflowNoticeMapper : ClassMapper<WorkflowNotice>
    {
        public WorkflowNoticeMapper()
        {
            // 1、映射到workflow_notice
            Table("workflow_notice");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}