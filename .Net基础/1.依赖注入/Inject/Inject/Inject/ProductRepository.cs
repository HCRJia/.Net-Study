using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inject.Inject
{
    public class ProductRepository:IProductRepository
    {
        public Guid Id { set; get; }

        public void GetProduct()
        {
            Console.WriteLine("查询商品仓储成功");
            Id = Guid.NewGuid();
        }
    }
}
