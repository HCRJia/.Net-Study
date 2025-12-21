using ObserverPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Subject
{
    /// <summary>
    /// 一只神奇的猫
    /// 
    /// 猫叫一声之后触发
    /// baby cry
    /// brother turn
    /// dog wang
    /// father roar
    /// mother whisper
    /// mouse run
    /// neighbor awake
    /// stealer hide
    /// 
    /// </summary>
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine("{0} Miao.....", this.GetType().Name);

            new Mouse().Run();//依赖
            new Chicken().Woo();
            new Baby().Cry();
            new Brother().Turn();
            new Dog().Wang();
            new Father().Roar();
            new Mother().Whisper();
            //new Mouse().Run();
            new Neighbor().Awake();
            //new Stealer().Hide();
        }
        //依赖太多，任何一个对象改动，都会导致Cat变化
        //违背了单一职责，不仅自己miao 还要触发各种动作，不稳定
        //加一个/减一个/调整顺序  Cat都得改

        //Cat职责：1 Miao  2 触发一系列动作  这是需求
        //实现上，其实多了一个，3 指定动作

        //Cat不稳定--这一堆对象--甩锅--自己不写让别人传递
        private List<IObserver> _ObserverList = new List<IObserver>();
        public void AddObserver(IObserver observer)
        {
            this._ObserverList.Add(observer);
        }
        public void MiaoObserver()
        {
            Console.WriteLine("{0} MiaoObserver.....", this.GetType().Name);
            if (this._ObserverList != null && this._ObserverList.Count > 0)
            {
                foreach (var item in this._ObserverList)
                {
                    item.Action();
                }
            }
        }

        private event Action MiaoHandler;
        public void MiaoEvent()
        {
            Console.WriteLine("{0} MiaoEvent.....", this.GetType().Name);
            if (this.MiaoHandler != null)
            {
                foreach (Action item in this.MiaoHandler.GetInvocationList())
                {
                    item.Invoke();
                }
            }
        }
    }
}
