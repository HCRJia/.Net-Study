using DecoratorPattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    /// <summary>
    ///  装饰器模式，结构型设计模式巅峰之作，组合+继承
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    AbstractStudent student = new StudentVip()
                    {
                        Id = 381,
                        Name = "候鸟"
                    };
                    //student.Study();
                    //BaseStudentDecorator decorator = new BaseStudentDecorator(student);
                    //AbstractStudent decorator = new BaseStudentDecorator(student);//里氏替换
                    //decorator.Study();
                    //student = new BaseStudentDecorator(student);//引用替换一下
                    //student.Study();

                    //StudentVideoDecorator decorator = new StudentVideoDecorator(student);
                    //BaseStudentDecorator decorator = new StudentVideoDecorator(student);//里氏替换
                    //AbstractStudent decorator = new StudentVideoDecorator(student);//里氏替换
                    /*student = new StudentVideoDecorator(student);*///引用替换一下
                    student = new StudentHomeworkDecorator(student);
                    student = new StudentCommentDecorator(student);
                    //student = new StudentVideoDecorator(student);
                    //student = new StudentUpdateDecorator(student);
                    student.Study();
                }
                {
                    int i = 3;
                    //int k = 4;
                    i = 4;
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
