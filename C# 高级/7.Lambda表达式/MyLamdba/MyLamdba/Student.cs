using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLamdba
{
    /// <summary>
    /// 学生实体
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine("{0} {1}学习.net高级开发", this.Id, this.Name);
        }

        public void StudyHard()
        {
            Console.WriteLine("{0} {1}努力学习.net高级开发", this.Id, this.Name);
        }

        ////学习实战班
        //public void StudyPractise()
        //{
        //    Console.WriteLine("{0} {1}更更努力学习", this.Id, this.Name);
        //}
    }

    /// <summary>
    /// 班级实体
    /// </summary>
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
    }
}
