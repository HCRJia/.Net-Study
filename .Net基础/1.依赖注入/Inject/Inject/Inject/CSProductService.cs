using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inject.Inject
{
    public class CSProductService : IProductService
    {
        public IProductRepository productRepository { set; get; }

        /*public CSProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }*/

        public void GetProduct()
        {
            productRepository.GetProduct();
            Console.WriteLine($"查询CS商品成功:{this.GetHashCode()}");
        }
    }
}
