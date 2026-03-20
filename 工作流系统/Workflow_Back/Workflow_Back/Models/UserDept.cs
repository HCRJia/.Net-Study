using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 用户部门关联模型
    /// </summary>
    [Table("ydt_user_dept")]
    public class UserDept
    {   
// 主键映射
            [Key,Identity]
            public long Id { get; set; }
public long UserId { get; set; }
public long DeptId { get; set; }
public long CreateTime { get; set; }
}

    /// <summary>
    /// 用户部门关联模型-用户部门关联模型表映射
    /// </summary>
    public sealed class UserDeptMapper : ClassMapper<UserDept>
    {
        public UserDeptMapper()
        {
            // 1、映射到ydt_user_dept
            Table("ydt_user_dept");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}