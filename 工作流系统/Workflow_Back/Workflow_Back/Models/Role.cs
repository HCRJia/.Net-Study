using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 角色模型
    /// </summary>
    [Table("ydt_role")]
    public class Role
    {   
public long RoleId { get; set; }
public long SystemId { get; set; }
public string RoleName { get; set; }
public string Memo { get; set; }
public bool IsDel { get; set; }
public long CreateUserId { get; set; }
public long CreateTime { get; set; }
public long UpdateUserId { get; set; }
public long UpdateTime { get; set; }
}

    /// <summary>
    /// 角色模型-角色模型表映射
    /// </summary>
    public sealed class RoleMapper : ClassMapper<Role>
    {
        public RoleMapper()
        {
            // 1、映射到ydt_role
            Table("ydt_role");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}