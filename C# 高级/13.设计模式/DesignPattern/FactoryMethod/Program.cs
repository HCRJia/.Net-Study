using FactoryMethod.Factory;
using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using FactoryPattern.War3.ServiceExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// 工厂方法：把简单工厂拆分成多个工厂，保证每个工厂的相对稳定
    ///           但是要多new一次工厂？ 难免，中间层，屏蔽业务类变化的影响，而且可以留下创建对象的扩展空间
    /// 
    /// 开闭原则：对扩展开发，对修改封闭
    /// 工厂方法完美遵循了开闭原则
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    Human human = new Human();//1 到处都是细节
                }
                {
                    IRace human = new Human();//2 左边是抽象  右边是细节
                }
                {
                    //human.
                    IFactory factory = new HumanFactory();//包一层
                    IRace race = factory.CreateRace();
                    //何苦  搞了这么多工厂 还不是创建个对象
                    //以前依赖的是Human  现在换成了HumanFactory

                    //1 工厂可以增加一些创建逻辑  屏蔽对象实例化的复杂度
                    //2 对象创建的过程中  可能扩展(尤其是ioc)
                }
                {
                    //Undead
                    IFactory factory = new UndeadFactory();
                    IRace race = factory.CreateRace();
                }
                {
                    IRace five = new Five();//修改
                }

                {
                    //five
                    IFactory factory = new FiveFactory();
                    IRace race = factory.CreateRace();
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
