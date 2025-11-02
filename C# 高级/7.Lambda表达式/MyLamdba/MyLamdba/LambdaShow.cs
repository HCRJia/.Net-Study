namespace MyLamdba
{
    public delegate void NoReturnNoParaOutClass();
    public delegate void GenericDelegate<T>();
    public class LambdaShow
    {
        public delegate void NoReturnNoPara();
        public delegate void NoReturnWithPara(int x, string y);//1 声明委托
        public delegate int WithReturnNoPara();
        public delegate string WithReturnWithPara(out int x, ref int y);

        public void Show()
        {
            //lambda演变历史

            {
                //.NetFramework1.0  1.1
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
            }
            int i = 10;
            {
                NoReturnWithPara method = new NoReturnWithPara(this.Study);
                method.Invoke(123, "张三");
            }
            {
                //.NetFramework2.0  匿名方法，delegate关键字
                //可以访问局部变量
                NoReturnWithPara method = new NoReturnWithPara(delegate (int id, string name)
                {
                    Console.WriteLine(i);
                    Console.WriteLine($"{id} {name} 学习.Net");
                });
                method.Invoke(234, "李四");
            }
            {
                //lambda表达式  参数列表=>方法体
                NoReturnWithPara method = new NoReturnWithPara(
                    (int id, string name) =>
                    {
                        Console.WriteLine($"{id} {name} 学习.Net");
                    });
                method.Invoke(123, "王五");
            }
            {
                NoReturnWithPara method = new NoReturnWithPara(
                    (id, name) =>//省略参数类型，编译器的语法糖，虽然没写，编译时还是有的，根据委托推算
                    {
                        Console.WriteLine($"{id} {name} 学习.Net");
                    });
                method.Invoke(123, "赵六");
            }
            {
                NoReturnWithPara method = new NoReturnWithPara(
                    (id, name) => Console.WriteLine($"{id} {name} 学习.Net"));
                //如果方法体只有一行，可以去掉大括号和分号
                method.Invoke(123, "甲");
            }
            {
                NoReturnWithPara method = (id, name) => Console.WriteLine($"{id} {name} 学习.Net");
                method.Invoke(123, "乙"); //new NoReturnWithPara可以省掉，也是语法糖，编译器自动加上
            }
            //lambda表达是什么？ lambda只是实力化委托的一个参数，就是个方法
            //lambda是匿名方法，但是编译的时候会分配一个名字
            //还会产生一个私有sealed类，这里增加一个方法
            {
                //lambda在多播委托
                NoReturnWithPara method = new NoReturnWithPara(this.Study);
                method += this.Study;
                method += (id, name) => Console.WriteLine($"{id} {name} 学习");

                method -= this.Study;
                method -= (id, name) => Console.WriteLine($"{id} {name} 学习");
                //多播委托里面的lambda无法移除， 不是2个实例，其实是2个不同的方法
                method.Invoke(345, "北纬23");
            }
            {
                //匿名方法或者lamdba表达式是不是只能是无返回值的
                Action action0 = () => { };
                Action<string> action1 = s => Console.WriteLine(s); //参数只有一个  可以省略小括号
                Func<int> func0 = () => DateTime.Now.Month;//如果方法体只有一行，去掉大括号分号return
                int iResult = func0.Invoke();
                Console.WriteLine("返回值：" + iResult);
            }
        }

        private void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
        }

        private void Study(int id, string name)
        {
            Console.WriteLine($"{id} {name} 学习.Net");
        }
    }
}
