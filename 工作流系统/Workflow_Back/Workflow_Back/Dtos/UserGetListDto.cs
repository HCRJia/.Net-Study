namespace Workflow_Back.Dtos
{
    /// <summary>
    /// 用户集合查询Dto
    /// </summary>
    public class UserGetListDto
    {
        public string UserName { get; set; } // 用户名

        public bool IsDel { get; set; } // 状态

    }
}
