namespace Workflow_Back.Dtos
{
    /// <summary>
    /// 用户角色结果Dto
    /// </summary>
    public class UserRoleDto
    {
        public string RoleName { set; get; }
        public long RoleId { get; set; }
        public long RoleParentId { get; set; }
    }
}
