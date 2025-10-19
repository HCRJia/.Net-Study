using MyOO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Service
{
    public class iPhone : BasePhone, IExtend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }

        public override void System()
        {
            Console.WriteLine($"{this.GetType().Name} System is IOS");
        }
        public void Call()
        {
            Console.WriteLine($"Use {this.GetType().Name} Call");
        }
        public void Open()
        {
            Console.WriteLine($"Use {this.GetType().Name} Open 1");
        }

        public void Close()
        {
            Console.WriteLine($"Use {this.GetType().Name} Close 2");
        }

        public void PlayGame()
        {
            Game game = new Game();
            game.Start();
            game.Fighting();
            game.Over();
        }
    }
}
