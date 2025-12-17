using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 代理模式：vpn代理  翻墙代理  火车票代理。。。
    ///          通过代理业务类去完成对真实业务类的调用，代理类不能扩展业务功能
    /// 
    /// 在不修改RealSubject前提下，插入功能
    /// 
    /// 包一层:没有什么技术问题是包一层不能解决的，如果有，就再包一层
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    Console.WriteLine("***********Real**************");

                    ISubject subject = new RealSubject();
                    subject.GetSomething();
                    //subject.DoSomething();
                }
                {
                    Console.WriteLine("***********Proxy**************");
                    ISubject subject = new ProxySubject();
                    subject.GetSomething();
                    //subject.DoSomething();
                }
                {
                    Console.WriteLine("***********Proxy**************");
                    ISubject subject = new ProxySubject();
                    subject.GetSomething();
                    //subject.DoSomething();
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
