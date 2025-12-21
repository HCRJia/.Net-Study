using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChainPattern
{
    /// <summary>
    /// 1 责任链模式介绍和应用
    /// 2 .net框架中的责任链模式
    /// 
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班公开课之设计模式特训，今天是Eleven老师为大家带来的责任链模式");
                ApplyContext context = new ApplyContext()
                {
                    Id = 506,
                    Name = "yoyo",
                    Hour = 100,
                    Description = "我想参加软谋教育的线下聚会",
                    AuditResult = false,
                    AuditRemark = ""
                };

                //{ //审批逻辑都写在上端，直接就是需求翻译，没有任何加工，谈不上什么扩展，面向过程
                //    if (context.Hour <= 8)
                //    {
                //        Console.WriteLine("PM审批通过");
                //    }
                //    else if (context.Hour <= 16)
                //    {
                //        Console.WriteLine("主管审批通过");
                //    }
                //    else
                //    {
                //        Console.WriteLine("************");
                //    }
                //}
                {
                    ////面向对象：封装--继承--多态   //1 转移了业务逻辑
                    ////也只是一个翻译机，翻译完+面向对象，其实完全没有设计没有加工没有思考
                    //AbstractAuditor pm = new PM()
                    //{
                    //    Name = "斗帝"
                    //};
                    //pm.Audit(context);
                    //if (!context.AuditResult)
                    //{
                    //    AbstractAuditor charge = new Charge()
                    //    {
                    //        Name = "象扑君"
                    //    };
                    //    charge.Audit(context);
                    //    if (!context.AuditResult)
                    //    {
                    //        AbstractAuditor manager = new Manager()
                    //        {
                    //            Name = "橙"
                    //        };
                    //        manager.Audit(context);
                    //        if (!context.AuditResult)
                    //        {
                    //            //找下一环节
                    //        }
                    //    }
                    //}
                }
                {
                    ////申请提交给项目经理---经理没有转交给主管---
                    ////这才符合实际情况，这才是有自己的理解思考和设计
                    ////2 转移了申请提交逻辑
                    //AbstractAuditor pm = new PM()
                    //{
                    //    Name = "斗帝"
                    //};
                    //pm.Audit(context);
                }
                {
                    //AbstractAuditor pm = new PM()
                    //{
                    //    Name = "斗帝"
                    //};
                    //AbstractAuditor charge = new Charge()
                    //{
                    //    Name = "象扑君"
                    //};
                    //AbstractAuditor manager = new Manager()
                    //{
                    //    Name = "橙"
                    //};
                    //AbstractAuditor chief = new Chief()
                    //{
                    //    Name = "Tenk"
                    //};
                    //AbstractAuditor ceo = new CEO()
                    //{
                    //    Name = "加菲猫"
                    //};

                    ////pm.SetNext(charge);
                    ////charge.SetNext(manager);
                    //pm.SetNext(manager);
                    //manager.SetNext(chief);
                    //chief.SetNext(ceo);
                    //ceo.SetNext(new ChiarMan()
                    //{
                    //    Name = "jack"
                    //});
                    //流程的可扩展

                    //pm.Audit(context);

                    AbstractAuditor auditor = AuditorBuilder.Build();
                    auditor.Audit(context);
                    if (!context.AuditResult)
                    {
                        Console.WriteLine("不干了！");
                    }
                    //3 把流程环节逻辑从业务类转移了
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
