using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Interface
{
    public abstract class BasePhone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }

        /// <summary>
        /// 子类都有这个方法，但又各不相同
        /// 抽象方法：约束下有这个方法；但是又各不相同
        /// </summary>
        public abstract void System();
        public void Call()
        {
            Console.WriteLine($"Use {this.GetType().Name} Call");
        }
    }
}
