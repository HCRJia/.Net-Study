using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 用户角色关联模型
    /// </summary>
    [Table("ydt_user_role")]
    public class UserRole
    {   
// 主键映射
            [Key,Identity]
            public long Id { get; set; }
public long UserId { get; set; }
public long RoleId { get; set; }
public long CreateTime { get; set; }
}

    /// <summary>
    /// 用户角色关联模型-用户角色关联模型表映射
    /// </summary>
    public sealed class UserRoleMapper : ClassMapper<UserRole>
    {
        public UserRoleMapper()
        {
            // 1、映射到ydt_user_role
            Table("ydt_user_role");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}