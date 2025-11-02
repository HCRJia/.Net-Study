using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLamdba
{
    /// <summary>
    /// 扩展方法：静态类里面的静态方法，第一个参数类型前面加上this
    /// </summary>
    public static class ExtendMethod
    {

        public static void StudyPractise(this Student student)
        {
            Console.WriteLine("{0} {1}学习.net实战开发", student.Id, student.Name);
        }

    }
}
