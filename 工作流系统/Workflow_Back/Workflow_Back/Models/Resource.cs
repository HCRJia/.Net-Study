using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 资源【菜单】模型
    /// </summary>
    [Table("ydt_resource")]
    public class Resource
    {   
public long ResourceId { get; set; }
public long SystemId { get; set; }
public string ResourceName { get; set; }
public long ParentId { get; set; }
public string ResourceUrl { get; set; }
public int Sort { get; set; }
public string ButtonClass { get; set; }
public string Icon { get; set; }
public bool IsShow { get; set; }
public long CreateUserId { get; set; }
public long CreateTime { get; set; }
public bool IsDel { get; set; }
public string Memo { get; set; }
public bool IsButton { get; set; }
public bool ButtonType { get; set; }
public string Path { get; set; }
}

    /// <summary>
    /// 资源【菜单】模型-资源【菜单】模型表映射
    /// </summary>
    public sealed class ResourceMapper : ClassMapper<Resource>
    {
        public ResourceMapper()
        {
            // 1、映射到ydt_resource
            Table("ydt_resource");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}