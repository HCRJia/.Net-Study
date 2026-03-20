using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 角色资源关联模型
    /// </summary>
    [Table("ydt_role_resource")]
    public class RoleResource
    {   
// 主键映射
            [Key,Identity]
            public long Id { get; set; }
public long RoleId { get; set; }
public long ResourceId { get; set; }
public long CreateTime { get; set; }
}

    /// <summary>
    /// 角色资源关联模型-角色资源关联模型表映射
    /// </summary>
    public sealed class RoleResourceMapper : ClassMapper<RoleResource>
    {
        public RoleResourceMapper()
        {
            // 1、映射到ydt_role_resource
            Table("ydt_role_resource");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}