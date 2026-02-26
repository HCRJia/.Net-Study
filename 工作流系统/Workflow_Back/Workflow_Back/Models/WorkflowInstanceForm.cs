using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("workflow_instance_form")]
    public class WorkflowInstanceForm
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key,Identity]
        public string Id { get; set; }
        /// <summary>
        /// 流程ID
        /// </summary>
        public string InstanceId { get; set; }
        /// <summary>
        /// 实例编号
        /// </summary>
        public string FormId { get; set; }
        /// <summary>
        /// 流程JSON内容
        /// </summary>
        public string FlowContent { get; set; }
        /// <summary>
        /// 当前节点ID
        /// </summary>
        public int FormType { get; set; }
        /// <summary>
        /// 当前节点类型
        /// </summary>
        public string FormUrl { get; set; }
        /// <summary>
        /// 当前节点名称
        /// </summary>
        public string FormData { get; set; }
    }

    /// <summary>
    /// -表映射
    /// </summary>
    public sealed class WorkflowInstanceFormMapper : ClassMapper<WorkflowInstanceForm>
    {
        public WorkflowInstanceFormMapper()
        {
            // 1、映射到workflow_instance_form
            Table("workflow_instance_form");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}