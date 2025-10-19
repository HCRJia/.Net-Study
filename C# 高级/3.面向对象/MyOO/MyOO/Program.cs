
using MyOO;
using MyOO.Interface;
using MyOO.Polymorphism;
using MyOO.Service;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

/// 1 封装继承多态
/// 2 重写overwrite(new)  覆写override 重载overload(方法)
/// 3 抽象类接口
/// 
/// 面向对象：OO
/// 
/// 封装：隔离，外部不用关心怎么实现，只要接口不变，内部可以随意扩展；
///       数据安全 private protected 数据结构，只能通过公开方法来访问，而不是随便改
///       降低耦合  提高重用性  尽量隐藏更多的东西
///  private protected  internal   public  
///      
/// 继承：子类拥有父类的一切属性和行为   代码重用
///       单继承,也就是只有一个父类
///       重写  覆写  重载
///       
/// 多态：一个类可以用过多个类型，就是多态 当然还有方法
///       编译时多态；运行时多态；
///       接口多态；继承多态；
///       
/// 接口抽象类：
///     抽象类：是一个父类+约束  父类是代码重用  约束是为多态变化    单继承
///       接口：就是一个约束     只有多态变化                        多实现
///     抽象类的出发点应该是代码重用，是为了当父类   is  a
///     接口纯粹为了约束，告诉别人一定有什么功能    can  do
/// 私人经验：
///     如果需要约束，一般选择接口，除非有代码需要重用
/// 
/// </summary>
#region PO面向过程
//拿着手机玩游戏
Console.WriteLine("打开手机。。。");
Console.WriteLine("手机联网。。。");
Console.WriteLine("启动游戏。。。");
Console.WriteLine("开始游戏。。。");
Console.WriteLine("Play。。。。。");
Console.WriteLine("结束游戏。。。");
//面向过程更符合人的思考方式  就是不方便扩展管理，尤其是项目复杂了
//不同的手机  不同的玩法  不同的游戏  手机配置不够 手机没电了 全写上去就很复杂
#endregion
#region OO面向对象
{
    Player player = new Player()
    {
        Id = 123,
        Name = "张三"
    };
    iPhone phone = new iPhone();
    player.PlayiPhone(phone);

    //BasePhone basePhone = new();

    Poly.Test();
}
#endregion