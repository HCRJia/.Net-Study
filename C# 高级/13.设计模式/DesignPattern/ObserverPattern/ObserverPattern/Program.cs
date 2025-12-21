using ObserverPattern.Observer;
using ObserverPattern.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    /// <summary>
    /// 观察者模式
    /// 对象和行为的分离
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    Console.WriteLine("***************Common******************");
                    Cat cat = new Cat();
                    cat.Miao();
                }
                {
                    Console.WriteLine("***************Observer******************");
                    Cat cat = new Cat();
                    cat.AddObserver(new Mouse());
                    cat.AddObserver(new Chicken());
                    cat.AddObserver(new Baby());
                    cat.AddObserver(new Brother());
                    cat.AddObserver(new Dog());
                    cat.AddObserver(new Father());
                    cat.AddObserver(new Mother());
                    cat.AddObserver(new Mouse());
                    cat.AddObserver(new Neighbor());
                    cat.AddObserver(new Stealer());
                    cat.MiaoObserver();
                }
                {
                    Console.WriteLine("***************Observer******************");
                    Cat cat = new Cat();
                    cat.AddObserver(new Chicken());
                    cat.AddObserver(new Baby());
                    cat.AddObserver(new Brother());
                    cat.AddObserver(new Dog());
                    cat.AddObserver(new Father());
                    cat.AddObserver(new Mother());
                    cat.AddObserver(new Mouse());
                    cat.AddObserver(new Neighbor());
                    cat.AddObserver(new Stealer());
                    cat.MiaoObserver();
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
