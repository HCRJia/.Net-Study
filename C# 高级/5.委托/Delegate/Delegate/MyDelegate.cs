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
        public delegate MyDelegateUse WithReturnWithPara(out int x, ref int y);

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
                //method.Invoke(out int a, ref b);
            }
            {
                WithReturnNoPara method = new WithReturnNoPara(this.Get);
                int i = method.Invoke();

                int k = this.Get();
            }

            {//多种途径实例化

            }

            {//多播委托

            }

        }

        public int Get()
        {
            return 1;
        }
        private MyDelegateUse ParaReturn(out int x, ref int y)
        {
            throw new Exception();
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

        public int add(int a, int b)
        {
            return a + b;
        }
    }
}
