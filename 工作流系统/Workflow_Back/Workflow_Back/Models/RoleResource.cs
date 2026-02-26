using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("role_resource")]
    public class RoleResource
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key,Identity]
        public long Id { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// 资源ID
        /// </summary>
        public long ResourceId { get; set; }
        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long CreateTime { get; set; }
    }

    /// <summary>
    /// -表映射
    /// </summary>
    public sealed class RoleResourceMapper : ClassMapper<RoleResource>
    {
        public RoleResourceMapper()
        {
            // 1、映射到role_resource
            Table("role_resource");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}