namespace Workflow_Back.CommonExceptions
{
    public class CommonExceptionResult
    {
        public string ErrorNo { set; get; } // 结果状态编号
        public string ErrorInfo { set; get; } //  结果状态信息
        public dynamic ErrorReason { set; get; } // 代表所有的Action结果
    }
}
