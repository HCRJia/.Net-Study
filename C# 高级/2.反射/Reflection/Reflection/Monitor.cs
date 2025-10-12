using DB.Interface;
using DB.SqlServer;
using System.Diagnostics;
using System.Reflection;

namespace Reflection
{
    public class Monitor
    {
        public static void Show()
        {
            Console.WriteLine("*******************Monitor*******************");
            long commonTime = 0;
            long reflectionTime1 = 0;
            long reflectionTime2 = 0;
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    IDBHelper iDBHelper = new SqlServerHelper();
                    iDBHelper.Query();
                }
                watch.Stop();
                commonTime = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    Assembly assembly = Assembly.Load("DB.SqlServer");//1 动态加载
                    Type dbHelperType = assembly.GetType("DB.SqlServer.SqlServerHelper");//2 获取类型
                    object oDBHelper = Activator.CreateInstance(dbHelperType);//3 创建对象
                    IDBHelper dbHelper = (IDBHelper)oDBHelper;//4 接口强制转换
                    dbHelper.Query();//5 方法调用
                }
                watch.Stop();
                reflectionTime1 = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Assembly assembly = Assembly.Load("DB.SqlServer");//1 动态加载
                Type dbHelperType = assembly.GetType("DB.SqlServer.SqlServerHelper");//2 获取类型
                for (int i = 0; i < 10000000; i++)
                {
                    //Assembly assembly = Assembly.Load("DB.SqlServer");//1 动态加载
                    //Type dbHelperType = assembly.GetType("DB.SqlServer.SqlServerHelper");//2 获取类型
                    object oDBHelper = Activator.CreateInstance(dbHelperType);//3 创建对象
                    IDBHelper dbHelper = (IDBHelper)oDBHelper;//4 接口强制转换
                    dbHelper.Query();//5 方法调用
                }
                watch.Stop();
                reflectionTime2 = watch.ElapsedMilliseconds;
            }

            Console.WriteLine("commonTime={0} reflectionTime1={1} reflectionTime2={2}", commonTime, reflectionTime1, reflectionTime2);
        }
    }
}
