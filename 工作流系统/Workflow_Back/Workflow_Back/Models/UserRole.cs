namespace Workflow_Back.Models
{
    /// <summary>
    /// 用户角色模型
    /// </summary>
    public class UserRole
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
