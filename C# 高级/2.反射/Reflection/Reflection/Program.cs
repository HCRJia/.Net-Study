
using DB.Interface;
using DB.MySql;
using DB.Oracle;
using DB.SqlServer;
using Reflection;
using System.Reflection;

/// <summary>
/// 1 dll-IL-metadata-反射
/// 2 反射加载dll，读取module、类、方法、特性
/// 3 反射创建对象，反射+简单工厂+配置文件  选修：破坏单例 创建泛型
/// 
/// 反射反射，程序员的快乐
/// 反射是无处不在的，MVC-Asp.Net-ORM-IOC-AOP 几乎所有的框架都离不开反射
/// 
/// 反编译工具不是用的反射，是一个逆向工程
/// IL：也是一种面向对象语言，但是不太好阅读
/// metadata元数据：数据清单，描述了DLL/exe里面的各种信息
/// 
/// 反射Reflection:System.Reflection，是.Net Framework提供的一个帮助类库，可以读取并使用metadata
/// 
/// 
/// 
/// 1 反射调用实例方法、静态方法、重载方法 选修:调用私有方法 调用泛型方法
/// 2 反射字段和属性，分别获取值和设置值
/// 3 反射的好处和局限
/// 4 第一次作业部署
/// 
/// 反射的优点： 动态  
/// 反射的缺点：
///     1 使用麻烦
///     2 避开编译器检查
///     3 性能问题！！！
///            100w次循环-----性能差异160倍，确实很难接受
///                          普通方法 41ms
///                          反射     6512ms
///                      -----但是，换个角度分析下，100次循环，反射耗时0.65ms
///                           也就是说，反射基本不会影响到你的程序性能，除非你循环太多了反射
///     缓存优化，把dll加载和类型获取  只执行一次
///            100w次循环-----性能差异160倍，确实很难接受
///                            普通方法 48ms
///                            反射     103ms
///                            反射影响是不是更小了，
///     MVC-Asp.Net-ORM-IOC-AOP都在用反射，几乎都有缓存
///     MVC&&ORM  启动很慢，完成了很多初始化，反射的那些东西
///               后面运行就很快
///     这才是使用反射的正确姿势！！！           
///                      
/// </summary>
/// 
{
    //Console.WriteLine("************************Common*****************");
    //IDBHelper iDBHelper = new MySqlHelper();
    //IDBHelper iDBHelper = new SqlServerHelper();
    //iDBHelper.Query();

    //MySqlHelper换成SqlServerHelper  就必须修改现有代码 重新编译 发布
}

// 反射
//有三种不同的加载方法
{
    //Assembly assembly = Assembly.Load("DB.MySql");
    ////1 动态加载 一个完整dll名称不需要后缀  从exe所在的路径进行查找
    //Assembly assembly1 = Assembly.LoadFile("D:\\Code\\.Net-Study\\C# 高级\\2.反射\\Reflection\\Reflection\\bin\\Debug\\net8.0\\DB.MySql.dll");
    //Assembly assembly2 = Assembly.LoadFrom("DB.MySql.dll");
    //Assembly assembly3 = Assembly.LoadFrom("D:\\Code\\.Net-Study\\C# 高级\\2.反射\\Reflection\\Reflection\\bin\\Debug\\net8.0\\DB.MySql.dll");

    //foreach (var type in assembly.GetTypes())
    //{
    //    //type.IsGenericType
    //    Console.WriteLine(type.Name);
    //    foreach (var method in type.GetMethods())
    //    {
    //        Console.WriteLine(method.Name);
    //    }
    //}
}

{
    Console.WriteLine("************************Reflection************************");
    Assembly assembly = Assembly.Load("DB.MySql");//1 动态加载
    Type type = assembly.GetType("DB.MySql.MySqlHelper");//2 获取类型 完整类型名称
    object oDBHelper = Activator.CreateInstance(type);//3 创建对象 仍然会实例化对象
    //oDBHelper.Query();
    //不能直接Query 为啥？  实际上oDBHelper是有Query方法的，只是因为编译器不认可
    //C#是一种强类型语言，静态语言，编译时就确定好类型保证安全
    //dynamic dDBHelper = Activator.CreateInstance(type);
    //dDBHelper.Query();//dynamic编译器不检查，运行时才检查
    IDBHelper iDBHelper = oDBHelper as IDBHelper;//4 类型转换  不报错，类型不对就返回null
    iDBHelper.Query();//5 方法调用
}

{
    ////封装上面的代码
    //Console.WriteLine("*****************Reflection+Factory+Config********************");
    IDBHelper iDBHelper = SimpleFactory.CreateInstance();
    iDBHelper.Query();
    //程序的可配置，通过修改配置文件就可以自动切换
    //实现类必须是事先已有的，而且在目录下面
    //没有写死类型，而是通过配置文件执行，反射创建的

    //可扩展:完全不修改原有代码，只是增加新的实现，copy，修改配置文件，就可以支持新功能
    //反射的动态加载和动态创建对象  以及配置文件结合
}


Console.ReadLine();