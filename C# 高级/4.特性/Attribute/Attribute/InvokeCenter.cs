using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    public class InvokeCenter
    {
        public static void ManagerStudent<T>(T student) where T : Student
        {
            Console.WriteLine($"{student.Id}_{student.Name}");
            student.Study();
            student.Answer("答案");

            Type type = student.GetType();
            if (type.IsDefined(typeof(CustomAttribute), true))
            {
                object[] oAttributeArray = type.GetCustomAttributes(typeof(CustomAttribute), true);
                foreach (CustomAttribute attr in oAttributeArray)
                {
                    attr.Show();
                }

                foreach(var prop in type.GetProperties())
                {
                    if(prop.IsDefined(typeof(CustomAttribute), true))
                    {
                        object[] pAttributeArray = prop.GetCustomAttributes(typeof(CustomAttribute), true);
                        foreach (CustomAttribute attr in pAttributeArray)
                        {
                            attr.Show();
                        }
                    }
                }
            }
        }

    }
}
