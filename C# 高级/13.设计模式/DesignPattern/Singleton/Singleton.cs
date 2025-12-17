using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 单例类：一个构造对象很耗时耗资源类型
    /// 懒汉式单例模式
    /// </summary>
    public class Singleton
    {
        /// <summary>
        /// 构造函数耗时耗资源
        /// </summary>
        private Singleton()
        {
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine("{0}被构造一次", this.GetType().Name);
        }
        /// <summary>
        /// 3 全局唯一静态  重用这个变量
        /// </summary>
        private static volatile Singleton _Singleton = null;
        //volatile 促进线程安全 让线程按顺序操作
        private static readonly object Singleton_Lock = new object();
        /// <summary>
        /// 2 公开的静态方法提供对象实例
        /// </summary>
        /// <returns></returns>
        public static Singleton CreateInstance()
        {
            if (_Singleton == null)//是_Singleton已经被初始化之后，就不要进入锁等待了
            {
                lock (Singleton_Lock)
                //保证任意时刻只有一个线程进入lock范围
                //也限制了并发，尤其是_Singleton已经被初始化之后
                {
                    //Thread.Sleep(1000);
                    //Console.WriteLine("等待锁1s之后才继续。。。");
                    if (_Singleton == null)//保证只实例化一次
                    {
                        _Singleton = new Singleton();
                    }
                }
            }
            return _Singleton;
        }

        

        //既然是单例，大家用的是同一个对象，用的是同一个方法，那还会并发吗  还有线程安全问题吗？
        public int iTotal = 0;
        public void Show()
        {
            //lock (Singleton_Lock)
            //{
                this.iTotal++;
            //}
        }

        public static void Test()
        {
            Console.WriteLine("Test1");
            Console.WriteLine(_Singleton.iTotal);
        }

    }
}
