using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChainPattern
{
    public class AuditorBuilder
    {
        /// <summary>
        /// 那就反射+配置文件
        /// 链子的组成都可以通过配置文件
        /// </summary>
        /// <returns></returns>
        public static AbstractAuditor Build()
        {
            AbstractAuditor pm = new PM()
            {
                Name = "斗帝"
            };
            AbstractAuditor charge = new Charge()
            {
                Name = "象扑君"
            };
            AbstractAuditor manager = new Manager()
            {
                Name = "橙"
            };
            AbstractAuditor chief = new Chief()
            {
                Name = "Tenk"
            };
            AbstractAuditor ceo = new CEO()
            {
                Name = "加菲猫"
            };

            pm.SetNext(charge);
            charge.SetNext(manager);
            //pm.SetNext(manager);
            manager.SetNext(chief);
            chief.SetNext(ceo);
            ceo.SetNext(new ChiarMan()
            {
                Name = "jack"
            });
            return pm;
        }
    }
}
