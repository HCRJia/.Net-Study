using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 包一层:没有什么技术问题是包一层不能解决的，如果有，就再包一层
    /// 比如来个日志记录,可以避免修改业务类，只需要修改代理类
    /// 再来个异常处理  
    /// 再来个性能提升--缓存结果-单例
    /// 
    /// 通过代理，能够为对象扩展功能(不是增加业务)而不去修改原始业务类，也就是包了一层，我的地盘听我的
    /// </summary>
    public class ProxySubject : ISubject
    {
        //组合一下
        private static ISubject _Subject = new RealSubject();
        public void DoSomething()
        {
            try
            {
                Console.WriteLine("prepare DoSomething...");
                _Subject.DoSomething();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private static Dictionary<string, bool> ProxyDictionary = new Dictionary<string, bool>();
        public bool GetSomething()
        {
            try
            {
                Console.WriteLine("prepare GetSomething...");
                string key = "Proxy_GetSomething";
                bool bResult = false;
                if (!ProxyDictionary.ContainsKey(key))
                {
                    bResult = _Subject.GetSomething();
                    ProxyDictionary.Add(key, bResult);
                }
                else
                {
                    bResult = ProxyDictionary[key];
                }
                return bResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
