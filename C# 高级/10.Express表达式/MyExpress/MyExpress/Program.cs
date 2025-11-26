using MyExpress;

/// <summary>
/// 1 什么是表达式目录树Expression
/// 2 动态拼装Expression
/// 3 基于Expression扩展应用
/// </summary>
try
{
    //{
    //    new List<int>().Where(i => i > 10);
    //    new List<int>().AsQueryable().Where(i => i > 10);
    //}
    {
        Console.WriteLine("****************认识表达式目录树*************");
        ExpressionTest.Show();
    }
    {
        Console.WriteLine("********************MapperTest********************");
        //ExpressionTest.MapperTest();
    }
    {
        Console.WriteLine("********************解析表达式目录树********************");
        //ExpressionVisitorTest.Show();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.Read();