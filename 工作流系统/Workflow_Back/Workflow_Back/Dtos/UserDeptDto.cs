namespace Workflow_Back.Dtos
{
    /// <summary>
    /// 用户部门结果Dto
    /// </summary>
    public class UserDeptDto
    {
        public string UserName { set; get; }

        public List<DeptDto> deptDtos { get; set; }
    }

    /// <summary>
    /// 部门Dto
    /// </summary>
    public class DeptDto
    {
        public long DeptId { set; get; }
        public string DeptName { set; get;}
    }
}
