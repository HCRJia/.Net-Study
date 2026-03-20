using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 子系统模型
    /// </summary>
    [Table("ydt_system")]
    public class System
    {   
public long SystemId { get; set; }
public string SystemName { get; set; }
public string SystemCode { get; set; }
public bool IsDel { get; set; }
public string Memo { get; set; }
public int Sort { get; set; }
public long CreateTime { get; set; }
public long CreateUserId { get; set; }
public long UpdateTime { get; set; }
}

    /// <summary>
    /// 子系统模型-子系统模型表映射
    /// </summary>
    public sealed class SystemMapper : ClassMapper<System>
    {
        public SystemMapper()
        {
            // 1、映射到ydt_system
            Table("ydt_system");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}