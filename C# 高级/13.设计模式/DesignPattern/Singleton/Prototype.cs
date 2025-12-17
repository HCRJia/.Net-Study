using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 原型模式：单例的基础上升级了一下，把对象从内存层面复制了一下，然后返回
    ///    是个新对象，但是又不是new出来的
    /// </summary>
    public class Prototype
    {
        /// <summary>
        /// 构造函数耗时耗资源
        /// </summary>
        private Prototype()
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
        private static volatile Prototype _Prototype = new Prototype();
        /// <summary>
        /// 2 公开的静态方法提供对象实例
        /// </summary>
        /// <returns></returns>
        public static Prototype CreateInstance()
        {
            Prototype prototype = (Prototype)_Prototype.MemberwiseClone();
            return prototype;
        }

        //既然是单例，大家用的是同一个对象，用的是同一个方法，那还会并发吗  还有线程安全问题吗？
        public int iTotal = 0;
        public void Show()
        {
            this.iTotal++;
        }

        //public static void Test()
        //{
        //    Console.WriteLine("Test1");
        //    Console.WriteLine(_Singleton.iTotal);
        //}

    }
}
