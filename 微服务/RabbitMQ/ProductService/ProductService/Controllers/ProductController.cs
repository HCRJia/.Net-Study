using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductService.Models;
using RabbitMQ.Client;
using System.Text;

namespace EBusiness.Controllers
{
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// 创建商品
        /// </summary>
        /// <param name="productCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<Product> CreateProduct(ProductCreateDto productCreateDto)
        {
            #region 1、生产者
            {
                // 1、创建连接工厂
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672,
                    Password = "guest",
                    UserName = "guest",
                    VirtualHost = "/"
                };
                using (var connection = factory.CreateConnection())
                {
                    var channel = connection.CreateModel();
                    // 2、定义队列
                    channel.QueueDeclare(queue: "product-create",
                                         durable: false,// 消息持久化(防止rabbitmq宕机导致队列丢失风险)
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string productJson = JsonConvert.SerializeObject(productCreateDto);
                    // string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(productJson);

                    // 3、发送消息
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true; // 设置消息持久化（个性化控制）
                    channel.BasicPublish(exchange: "",
                                         routingKey: "product-create",
                                         basicProperties: properties,
                                         body: body);
                }
                _logger.LogInformation("成功创建商品");
            }
            #endregion

            return null;
        }
    }
}