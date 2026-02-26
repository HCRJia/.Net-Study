using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_codegenerator.generators
{
    /// <summary>
    /// 模板变量
    /// </summary>
    public class Entity
    {
        public string name { set; get; } // 类名
        public string comment { set; get; } // 注释
        public string tablename { set; get; } // 表名
        public List<Propertity> propertities { set; get; }  // 字段结合
    }

    /// <summary>
    /// 模板集合对象
    /// </summary>
    public class Propertity
    {
        public string name { set; get; }  // 字段名
        public string type { set; get; } // 字段转换后的C#类型
        public string comment { set; get; } // 字段注释
    }
}
