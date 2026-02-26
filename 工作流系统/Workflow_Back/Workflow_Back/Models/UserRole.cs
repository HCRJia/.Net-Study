using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("user_role")]
    public class UserRole
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key,Identity]
        public long Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long CreateTime { get; set; }
    }

    /// <summary>
    /// -表映射
    /// </summary>
    public sealed class UserRoleMapper : ClassMapper<UserRole>
    {
        public UserRoleMapper()
        {
            // 1、映射到user_role
            Table("user_role");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}