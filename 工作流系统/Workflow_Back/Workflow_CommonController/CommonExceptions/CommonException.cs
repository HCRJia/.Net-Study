namespace Workflow_Back.CommonExceptions
{
    /// <summary>
    /// 通用异常
    /// </summary>
    public class CommonException : Exception
    {
        public CommonException()
        {
        }

        public CommonException(string? message) : base(message)
        {
        }

        public string ErrorNo { get; set; } // 异常编号
        public string ErrorInfo { get; set; }  // 抽象 message
        public string ErrorReason { set; get; } // 抽象 StackTrace
    }
}
