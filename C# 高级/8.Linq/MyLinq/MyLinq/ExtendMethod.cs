using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    /// <summary>
    /// 扩展方法：静态类里面的静态方法，第一个参数类型前面加上this
    /// </summary>
    public static class ExtendMethod
    {
        /// <summary>
        /// 一个方法，完成重复的步骤，
        /// 但是判断条件不同？ 不同的通过委托传递
        /// 
        /// 1 完成对一组学生的过滤，把重复的代码写在这里，把变化的部分通过委托传递
        /// 2 泛型完成对不同类型的数据过滤
        /// 3 迭代器模式，完成了数据的按需获取，延迟加载
        /// 
        /// Linq To Object  在Enumerable类，针对IEnumerable数据，指的是内存数据
        ///     --Where：把对数据过滤的通用操作完成，把可变的过滤逻辑交给委托
        ///      Select：把对数据转化的通用操作完成，把可变的转换逻辑交给委托
        ///      OrderBy...............
        ///      Linq 其实就是把对数据操作的通用部分完成，把可变的交给委托，使用者只用关心可变部分，其实Linq就是这么一个封装，但确实很好用
        ///      
        /// Linq To Sql  在Queryable类，针对IQueryable数据，   操作数据库
        ///      程序访问数据库，都是需要Ado.Net+Sql
        ///      封装一下通用数据库操作，可变的是SQL，SQL通过表达式目录树来传递，这个是可以解析的
        ///     
        /// Linq To XML  封装一下通用的对XML文件的操作，可变的通过委托来传递
        /// 
        /// 这是一种伟大的封装思想，希望通过一种模式完成一切数据源的访问，
        /// 让开发者彻底变成小白，（当年，潮流是傻瓜式，这种很厉害；现代化的开发有更高要求）
        /// Linq to Nosql
        /// Linq to Redis
        /// Linq to Cache
        /// Linq to Excel
        /// Linq to json
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static IEnumerable<T> ElevenWhereIterator<T>(this IEnumerable<T> resource, Func<T, bool> func)
        {
            foreach (var item in resource)
            {
                Console.WriteLine("进入数据检测");
                Thread.Sleep(100);
                if (func.Invoke(item))
                {
                    yield return item;//yield 跟IEnumerable配对使用
                }
            }
            //var list = new List<T>();
            //foreach (var item in resource)
            //{
            //    if (func.Invoke(item))
            //    {
            //        list.Add(item);
            //    }
            //}
            //return list;
        }

        public static List<T> ElevenWhere<T>(this List<T> resource, Func<T, bool> func)
        {
            var list = new List<T>();
            foreach (var item in resource)
            {
                Console.WriteLine("进入数据检测");
                Thread.Sleep(100);
                if (func.Invoke(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }









        public static void StudyPractise(this Student student)
        {
            Console.WriteLine("{0} {1}跟着Mark老师学习.net实战开发", student.Id, student.Name);
        }

        public static int ToInt(this int? i)
        {
            //if (i == null)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return i.Value;
            //}

            return i ?? 0;
        }

        public static string ToLength(this string text, int length = 15)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "空";
            }
            else if (text.Length > length)
            {
                return ($"{text.Substring(0, length)}...");
            }
            else
            {
                return text;
            }
        }

        public static string ToStringCustom<T>(this T t)
        {
            if (t is Guid)
            {
                return t.ToString().Replace("-", "");
            }
            //.....
            else
            {
                return t.ToString();
            }
        }

        public static string ToStringNew(this object o)
        {
            if (o is null)
            {
                return "";
            }
            else
            {
                return o.ToString();
            }
        }
    }
}
