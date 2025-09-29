using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    /// <summary>
    /// 泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClass<T>
    {
        public T _T;
    }

    public class GenericClassChild1: GenericClass<int>
    {
    }

    public class GenericClassChild2<T> : GenericClass<T>
    {
    }

    /// <summary>
    /// 泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericInterface<T>
    {
        T GetT(T t);
    }

    public delegate void SayHi<T>(T t);//泛型委托
}
