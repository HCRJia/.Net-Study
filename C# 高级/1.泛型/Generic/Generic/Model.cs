namespace MyGeneric
{
    public interface IWork
    {
        void Work();
    }


    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Hi()
        { }

    }

    public class Chinese : People, IWork
    {
        public void SayHi()
        {
            Console.WriteLine("你好");
        }

        public void Work()
        {
            throw new NotImplementedException();
        }
    }

    public class ZheJiang : Chinese
    {
        public string XiHu { get; set; }
        public void SayHello()
        {
            Console.WriteLine("我是浙江人");
        }
    }


    public class Japanese : IWork
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public void Work()
        {
            Console.WriteLine("工作");
        }
    }
}
