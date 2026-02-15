using JadeFramework.Core.Dapper;
using JadeFramework.Core.Domain.Permission;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    [Table("role")]
    public class Role
    {
        // 主键映射
        [Key, Identity]
        public int Id { get; set; }

        public string RoleName { get; set; }
    }

    /// <summary>
    /// 角色模型-角色表映射
    /// </summary>
    public sealed class RoleMapper : ClassMapper<Role>
    {
        public RoleMapper()
        {
            // 1、映射到ydt_user
            Table("role");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}
