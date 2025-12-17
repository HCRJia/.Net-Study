using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 单例模式：保证进程中，某个类只有一个实例
    ///           
    /// 1 怎么保证呢？怎么样强制保证呢？
    /// 2 有什么好处呢？
    /// 
    /// 做到了单例，
    /// 有什么好处呢？
    /// 
    /// 即使是单例，变量也不是线程安全的，单例不是为了保证线程安全
    /// 单例的好处就是单例，就是全局唯一的一个实例：
    /// 应对一些特殊情况，比如数据库连接池(内置了资源)  全局唯一号码生成器
    /// 
    /// 单例可以避免重复创建，但是也会常驻内存
    /// 除非是真的有必要，否则不要单例
    /// </summary>
    class Program
    {
        /// <summary>
        /// 静态字段在程序进程只有一个
        /// </summary>
        //public static Singleton singleton = new Singleton();

        static void Main(string[] args)
        {
            try
            {
                //为什么要有单例设计模式？
                //构造对象耗时耗资源，很多地方都需要去new， 这个方法 其他方法  其他类
                //想避免重复构造，公开静态字段 
                //1 提前构造  2 没办法保证都是用这个(其他人还是new了一下) 
                //Singleton singleton = new Singleton();
                //singleton.Show();

                //{
                //    ////保证进程中，某个类只有一个实例
                //    ////1 构造函数私有化 避免别人还去new
                //    ////2 公开的静态方法提供对象实例
                //    ////3 初始化一个静态字段用于返回 保证全局都是这一个
                //    //Singleton singleton1 = Singleton.CreateInstance();
                //    //Singleton singleton2 = Singleton.CreateInstance();
                //    //Singleton singleton3 = Singleton.CreateInstance();
                //    //Console.WriteLine(object.ReferenceEquals(singleton1, singleton2));
                //    //Console.WriteLine(object.ReferenceEquals(singleton3, singleton2));
                //}
                //{
                //    for (int i = 0; i < 5; i++)
                //    {
                //        Task.Run(() =>//启动线程完成--5个线程并发执行，同时去执行这个方法
                //        {
                //            Singleton singleton1 = Singleton.CreateInstance();
                //            singleton1.Show();
                //        });
                //    }

                //    Thread.Sleep(10000);
                //    Console.WriteLine("第一波多线程后，再度来请求实例");
                //    for (int i = 0; i < 5; i++)
                //    {
                //        Task.Run(() =>//启动线程完成--5个线程并发执行，同时去执行这个方法
                //        {
                //            Singleton singleton1 = Singleton.CreateInstance();
                //            singleton1.Show();
                //        });
                //    }
                //}
                //{
                //    Singleton.Test();
                //}
                //{
                //    SingletonSecond.Test();
                //}
                {
                    List<Task> tasks = new List<Task>();
                    for (int i = 0; i < 10000; i++)
                    {
                        tasks.Add(Task.Run(() =>
                        {
                            Singleton singleton = Singleton.CreateInstance();
                            singleton.Show();
                        }));
                    }
                    Task.WaitAll(tasks.ToArray());
                    Singleton.Test();
                    //iTotal 是0  1   10000  还是其他的
                    //其他值，1到10000范围内都可能   线程不安全

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
