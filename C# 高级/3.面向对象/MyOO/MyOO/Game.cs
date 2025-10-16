using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO
{
    public class Game
    {
        public void Start()
        {
            Console.WriteLine($"{this.GetType().Name} Start");
        }

        public void Fighting()
        {
            Console.WriteLine($"{this.GetType().Name} Fighting");
        }

        public void Over()
        {
            Console.WriteLine($"{this.GetType().Name} Over");
        }
    }
}
