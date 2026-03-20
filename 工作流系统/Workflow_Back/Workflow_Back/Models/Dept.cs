using JadeFramework.Core.Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workflow_Back.Models
{
    /// <summary>
    /// 部门模型
    /// </summary>
    [Table("ydt_dept")]
    public class Dept
    {   
public long DeptId { get; set; }
public long SystemId { get; set; }
public string DeptName { get; set; }
public string DeptCode { get; set; }
public long ParentId { get; set; }
public string Path { get; set; }
public bool IsDel { get; set; }
public string Memo { get; set; }
public long CreateUserId { get; set; }
public long CreateTime { get; set; }
}

    /// <summary>
    /// 部门模型-部门模型表映射
    /// </summary>
    public sealed class DeptMapper : ClassMapper<Dept>
    {
        public DeptMapper()
        {
            // 1、映射到ydt_dept
            Table("ydt_dept");

            // 2、自动映射【字段和属性】
            AutoMap();
        }
    }
}