using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 用户模型
    /// </summary>
    [Table("ydt_user")]
    public class User
    {   
public long UserId { get; set; }
public long SystemId { get; set; }
public string Account { get; set; }
public string UserName { get; set; }
public string JobNumber { get; set; }
public string Password { get; set; }
public string HeadImg { get; set; }
public bool IsDel { get; set; }
public long CreateUserId { get; set; }
public long CreateTime { get; set; }
public long UpdateUserId { get; set; }
public long UpdateTime { get; set; }
}

    /// <summary>
    /// 用户模型-用户模型表映射
    /// </summary>
    public sealed class UserMapper : ClassMapper<User>
    {
        public UserMapper()
        {
            // 1、映射到ydt_user
            Table("ydt_user");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}