using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 用户模型
    /// </summary>
    [Table("user")]
    public class User
    {
        // 主键映射
        [Key, Identity]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// 用户模型-用户表映射
    /// </summary>
    public sealed class UserMapper : ClassMapper<User>
    {
        public UserMapper()
        {
            // 1、映射到ydt_user
            Table("user");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}
