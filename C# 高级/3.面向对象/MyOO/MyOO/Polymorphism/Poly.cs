namespace MyOO.Polymorphism
{
    public class Poly
    {
        public static void Test()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");



            ParentClass instance = new ChildClass();
            //instance.VirtualMethod("");
            //instance.VirtualMethod();

            Console.WriteLine("下面是instance.CommonMethod()");
            instance.CommonMethod();//子类new隐藏  父类方法   普通方法由编译时决定--提高效率

            Console.WriteLine("下面是instance.VirtualMethod()");
            instance.VirtualMethod();//子类覆写的虚方法  子类方法  虚方法由运行时决定的--多态灵活
            Console.WriteLine("下面是instance.AbstractMethod()");
            instance.AbstractMethod();//子类实现的抽象方法  子类方法  抽象方法由运行时决定的--多态灵活

            //父类方法 1  子类方法2    111  222


            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
        }
        //{
        // ChildClass instance = new ChildClass();
        //}
    }

    #region abstract
    public abstract class ParentClass
    {

        public ParentClass(int id)
        { }

        /// <summary>
        /// CommonMethod
        /// </summary>
        public void CommonMethod()
        {
            Console.WriteLine("ParentClass CommonMethod");
        }

        /// <summary>
        /// virtual  虚方法  必须包含实现 但是可以被重载
        /// </summary>
        public virtual void VirtualMethod()
        {
            Console.WriteLine("ParentClass VirtualMethod");
        }

        public virtual void VirtualMethod(string name)
        {
            Console.WriteLine("ParentClass VirtualMethod");
        }

        public abstract void AbstractMethod();
    }

    public class ChildClass : ParentClass
    {
        /// <summary>
        /// 实例化子类的时候，是先完成父类的实例化的
        /// </summary>
        public ChildClass()
            : base(3)//调用父类的构造函数
        {
        }

        /// <summary>
        /// new 隐藏
        /// </summary>
        public new void CommonMethod()
        {
            Console.WriteLine("ChildClass CommonMethod");
            // base this
        }

        /// <summary>
        /// virtual 可以被覆写
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override void VirtualMethod()
        {
            Console.WriteLine("ChildClass VirtualMethod");
            base.VirtualMethod();//base表示调用直接父类的这个方法
        }

        /// <summary>
        /// 抽象方法必须覆写
        /// </summary>
        public sealed override void AbstractMethod()
        {
            Console.WriteLine("ChildClass AbstractMethod");
        }
    }

    public class GrandClass : ChildClass
    {
        //public override void AbstractMethod()
        //{
        //    base.AbstractMethod();
        //}

        public override void VirtualMethod()
        {
            base.VirtualMethod();
        }
    }
    #endregion abstract
}
