using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("workflow_category")]
    public class WorkflowCategory
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        [Key,Identity]
        public string Id { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }

    /// <summary>
    /// -表映射
    /// </summary>
    public sealed class WorkflowCategoryMapper : ClassMapper<WorkflowCategory>
    {
        public WorkflowCategoryMapper()
        {
            // 1、映射到workflow_category
            Table("workflow_category");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}