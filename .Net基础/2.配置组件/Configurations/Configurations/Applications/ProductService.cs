using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.Applications
{
    public class ProductService
    {
        /// <summary>
        /// 1、配置对象
        /// </summary>
        public ProductServiceSettings Settings { get; set; }

        public ProductService(IOptions<ProductServiceSettings> settings)
        {
            Settings = settings.Value;
        }

        /// <summary>
        /// 查询商品方法
        /// </summary>
        public void GetProduct()
        {
            // 2、使用配置对象
            bool SecletType = Settings.SecletType;
            if (SecletType)
            {
                Console.WriteLine("从MySQL中查询商品数据");
            }
            else
            {
                Console.WriteLine("从redis中查询商品数据");
            }
        }
    }
}
