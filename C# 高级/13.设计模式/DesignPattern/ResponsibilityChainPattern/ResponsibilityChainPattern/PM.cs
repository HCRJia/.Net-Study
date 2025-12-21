using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChainPattern
{
    /// <summary>
    /// 职责问题：
    /// 1 权限范围内，审批通过
    /// 2 权限范围外，交给下一环节审批
    /// 写的代码又多了一个，指定下一环节
    /// 甩锅大法
    /// </summary>
    public class PM : AbstractAuditor
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"This is {this.GetType().Name} {this.Name} Audit");
            if (context.Hour <= 8)
            {
                context.AuditResult = true;
                context.AuditRemark = "允许请假！";
            }
            else
            {
                base.AuditNext(context);
                //if (this._NextAuditor != null)
                //{
                //    this._NextAuditor.Audit(context);
                //}
                //AbstractAuditor charge = new Charge()
                //{
                //    Name = "象扑君"
                //};
                //charge.Audit(context);
            }
        }
    }
}
