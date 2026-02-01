namespace Workflow_Back.CommonResults
{
    public class CommonResult
    {
        public string ErrorNo { set; get; } // 结果状态编号
        public string ErrorInfo { set; get; } //  结果状态信息
        public dynamic Result { set; get; } // 代表所有的Action结果
    }
}
