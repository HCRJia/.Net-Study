using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inject.Inject
{
    public class ProductService : IProductService
    {
        public ProductRepository productRepository { set; get; }

        public ProductService(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void GetProduct()
        {
            productRepository.GetProduct();
            Console.WriteLine($"查询商品成功:{productRepository.Id}");
        }
    }
}
