using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 1  抽象方法/虚方法/普通方法
    /// 2  模板方法设计模式
    /// 3  钩子方法
    /// 
    /// 面向对象：万物皆对象，类来映射现实生活的对象
    /// 业务升级--活期/定期--
    /// 差别很小，就加判断(违背单一职责)
    /// 差别比较多，尤其是类比较复杂，类型拆分下
    /// 
    /// 拆分之后，自然就有父类，代码重用--普通方法
    /// 利率：每个客户端都有利率，但是各不一样--抽象方法
    /// Show：部分客户端是一样的，个别客户端不一样--虚方法
    /// 
    /// 有个复杂的多步骤业务，定义一个父类(模板)，模板负责完成流程，把步骤分解，固定不变的当前类--各不相同的子类--有的相同有的不同虚方法
    /// 就是把部分行为做了分离，
    /// 好处：就是可以扩展；职责分明；
    /// 
    /// 模板方法设计模式，好像就只是抽象类--子类
    /// 设计模式没那么神奇，只不过是把常用的东西跟场景结合，沉淀下来起个名字
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //MethodTest.Show();
                //{
                //    Client client = new Client();
                //    client.Query(387, "天道无情", "123456");
                //}
                {
                    AbstractClient client = new ClientCurrent();
                    client.Query(387, "天道无情", "123456");
                }
                {
                    AbstractClient client = new ClientRegular();
                    client.Query(448, "一点半", "000000");
                }
                {
                    AbstractClient client = new ClientVip();
                    client.Query(259, "Gain", "251146");
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
