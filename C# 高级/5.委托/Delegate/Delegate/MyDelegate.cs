using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate
{
    public delegate void NoReturnNoParaOutClass();
    public class MyDelegateUse //: System.MulticastDelegate
    {
        /// <summary>
        /// 1 委托在IL就是一个类
        /// 2 继承自System.MulticastDelegate 特殊类-不能被继承
        /// </summary>
        public delegate void NoReturnNoPara();
        public delegate void NoReturnWithPara(int x, int y);//1 声明委托
        public delegate int WithReturnNoPara();

        public class OtherClass
        {
            public int add(int a, int b)
            {
                return a + b;
            }
        }

        // 委托的声明
        public delegate int AddDele1(int a, int b);
        public delegate int AddDele2(int a, int b);
        public delegate int AddDele3(int a, int b);
        public void DelegateUse()
        {
            OtherClass other = new();

            AddDele1 method1 = new AddDele1(other.add); //1 委托的实例化  要求传递一个参数类型 返回值都跟委托一致的方法,
            AddDele2 method2 = other.add; // 2 简化写法 
            AddDele2 method3 = delegate (int a, int b) //匿名方法 
            {
                return a + b;
            };

            int result1 = method1.Invoke(1, 2);
            Console.WriteLine("Method1: " + result1);

            int result2 = method2.Invoke(1, 2);
            Console.WriteLine("Method2: " + result2);

            int result3 = method3(1, 2); // 也可以省略.Invoke
            Console.WriteLine("Method3: " + result3);
        }

        public void Show()
        {
            //System.MulticastDelegate
            Student student = new Student()
            {
                Id = 96,
                Name = "一生为你"
            };
            student.Study();
            {
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                //2 委托的实例化  要求传递一个参数类型 返回值都跟委托一致的方法,
                method.Invoke();//3委托实例的调用  参数和委托约束的一致
                this.DoNothing();//效果跟直接调用方法一致
                method();//可以省略.Invoke
                method.BeginInvoke(null, null);//启动一个线程完成计算
                //method.EndInvoke(null);

                //委托就是一个类 为什么要用委托？ 这个类的实例可以放入一个方法，实例Inovke时，就调用方法
                //说起来还是在执行方法,为啥要做成三个步骤？ 唯一的差别，就是把方法放入了一个对象/变量
            }
            {
                //WithReturnWithPara method = new WithReturnWithPara(this.ParaReturn);//严格一致
                //method += this.ParaReturn;
                //method.Invoke(out int a, ref b);
            }
            {
                WithReturnNoPara method = new WithReturnNoPara(this.Get);
                int i = method.Invoke();

                int k = this.Get();
            }

            {
                //Action Func  .NetFramework3.0出现的
                //Action 系统提供  0到16个泛型参数  不带返回值  委托
                //Action action = new Action(this.DoNothing);
                Action action0 = this.DoNothing;//是个语法糖，就是编译器帮我们添加上new Action
                Action<int> action1 = this.ShowInt;
                Action<int, string, DateTime, long, int, string, DateTime, long, int, string, DateTime, long, int, string, DateTime, long> action16 = null;

                //Func 系统提供  0到16个泛型参数  带泛型返回值  委托
                Func<int> func0 = this.Get;
                int iResult = func0.Invoke();
                Func<int, string> func1 = this.ToString;
                Func<int, string, DateTime, long, int, string, DateTime, long, int, string, DateTime, long, int, string, DateTime, long, string> func16 = null;
            }
            {
                Action action0 = this.DoNothing;
                NoReturnNoPara method = this.DoNothing;
                //为啥框架要提供这种委托呢？  框架提供这种封装，自然是希望大家都统一使用Action/Func
                this.DoAction(action0);
                //this.DoAction(method);
                //委托的本质是类，Action和NoReturnNoPara是不同的类，虽然实例化都可以传递相同的方法，但是没有父子关系，所以是不能替换的
                //就像Student和Teacher两个类，实例化都是传递id/name，但是二者不能替换的

                //更进一步，框架中出现过N多个委托,委托的签名是一致的，实例化完的对象缺不能通用
                //new Thread(new ParameterizedThreadStart()).Start();
                //ThreadPool.QueueUserWorkItem(new WaitCallback())
                //Task.Run(new Action<object>());
                //本身实例化的时候，参数都是一样的，都是id/name，但却是不同的类型，导致没法通用
                //Action和Func  框架预定义的，新的API一律基于这些委托来封装
            }

            {
                //多种途径实例化  实例化的限制就是方法的参数列表&返回值类型必须和委托约束的一致
                {
                    Action method = this.DoNothing;
                }
                {
                    Action method = DoNothingStatic;
                }
                {
                    Action method = new Student().Study;
                }
                {
                    Action method = Student.StudyAdvanced;
                }
            }

            {
                //多播委托有啥用呢？一个委托实例包含多个方法，可以通过+=/-=去增加/移除方法，Invoke时可以按顺序执行全部动作

                //多播委托:任何一个委托都是多播委托类型的子类，可以通过+=去添加方法
                //+=  给委托的实例添加方法，会形成方法链，Invoke时，会按顺序执行系列方法
                Action method = this.DoNothing;
                method += this.DoNothing;
                method += DoNothingStatic;
                method += new Student().Study;
                method += Student.StudyAdvanced;
                //method.BeginInvoke(null, null);//启动线程来完成计算  会报错，多播委托实例不能异步
                foreach (Action item in method.GetInvocationList())
                {
                    item.Invoke();
                    item.BeginInvoke(null, null);
                }
                //method.Invoke();
                //-=  给委托的实例移除方法，从方法链的尾部开始匹配，遇到第一个完全吻合的，移除，且只移除一个，如果没有匹配，就啥事儿不发生
                method -= this.DoNothing;
                method -= DoNothingStatic;
                method -= new Student().Study;//去不掉  原因是不同的实例的相同方法，并不吻合
                method -= Student.StudyAdvanced;
                method.Invoke();
                //中间出现未捕获的异常，直接方法链结束了

            }
            {
                Func<int> func = this.Get;
                func += this.Get2;
                func += this.Get3;
                int iResult = func.Invoke();
                //结果是3  以最后一个为准，前面的丢失了。。所以一般多播委托用的是不带返回值的
            }

        }

        private void DoAction(Action act)
        {
            act.Invoke();
        }


        private string ToString(int i)
        {
            return i.ToString();
        }

        private void ShowInt(int i)
        { }

        public int Get()
        {
            return 1;
        }
        public int Get2()
        {
            return 2;
        }
        public int Get3()
        {
            return 3;
        }


        private void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
        }
        private static void DoNothingStatic()
        {
            Console.WriteLine("This is DoNothingStatic");
        }
    }

    public class OtherClass
    {
        public void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
        }
        public static void DoNothingStatic()
        {
            Console.WriteLine("This is DoNothingStatic");
        }
    }
}
