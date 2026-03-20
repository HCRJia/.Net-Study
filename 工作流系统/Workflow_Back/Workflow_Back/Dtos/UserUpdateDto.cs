namespace Workflow_Back.Dtos
{
    /// <summary>
    /// 用户更新Dto
    /// </summary>
    public class UserUpdateDto
    {
       // public long UserId { get; set; }
        public string Account { get; set; }
        public string UserName { get; set; }
        public string JobNumber { get; set; }
        public long CreateTime { get; set; }
        public bool IsDel { get; set; }
    }
}
