// See https://aka.ms/new-console-template for more information
using Configurations.Applications;
using Configurations.Binds;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

Console.WriteLine("Hello, World!");

#region 1、json配置读取
{
    /*// 1、构造配置对象
    ConfigurationBuilder builder = new ConfigurationBuilder();
    builder.AddJsonFile("appsettings.json");
    IConfiguration configuration = builder.Build();

    // 2、读取配置信息
    string ApplicatoinName = configuration["AppSettings:ApplicatoinName"];
    string Version = configuration["AppSettings:Version"];

    Console.WriteLine($"ApplicatoinName:{ApplicatoinName}");
    Console.WriteLine($"Version:{Version}");*/
}
#endregion

#region 2、xml配置读取
{
    /*// 1、构造配置对象
    ConfigurationBuilder builder = new ConfigurationBuilder();
    builder.AddXmlFile("appsettings.xml");
    IConfiguration configuration = builder.Build();

    // 2、读取配置信息
    string ApplicatoinName = configuration["AppSettings:ApplicatoinName"];
    string Version = configuration["AppSettings:Version"];

    Console.WriteLine($"ApplicatoinName:{ApplicatoinName}");
    Console.WriteLine($"Version:{Version}");*/
}
#endregion

#region 3、yaml配置读取
{
    /* // 1、构造配置对象
     ConfigurationBuilder builder = new ConfigurationBuilder();
     builder.AddYamlFile("appsettings.yaml");
     IConfiguration configuration = builder.Build();

     // 2、读取配置信息
     string ApplicatoinName = configuration["AppSettings:ApplicatoinName"];
     string Version = configuration["AppSettings:Version"];

     Console.WriteLine($"ApplicatoinName:{ApplicatoinName}");
     Console.WriteLine($"Version:{Version}");*/
}
#endregion

#region 4、命令行配置读取
{
    /*// 1、构造配置对象
    ConfigurationBuilder builder = new ConfigurationBuilder();
    builder.AddCommandLine(args);
    IConfiguration configuration = builder.Build();
    // 2、读取配置信息
    string ApplicatoinName = configuration["ApplicatoinName"];
    string Version = configuration["Version"];

    Console.WriteLine($"ApplicatoinName:{ApplicatoinName}");
    Console.WriteLine($"Version:{Version}");

    Console.ReadKey();*/
}
#endregion

#region 5、自定义配置读取
{
    // 1、构造配置对象
    /*ConfigurationBuilder builder = new ConfigurationBuilder();
    builder.AddText("appsettings.txt");
    IConfiguration configuration = builder.Build();

    // 2、读取配置信息
    string ApplicatoinName = configuration["AppSettings.ApplicatoinName"];
    string Version = configuration["AppSettings.Version"];

    Console.WriteLine($"ApplicatoinName:{ApplicatoinName}");
    Console.WriteLine($"Version:{Version}");

    Console.ReadKey();*/
}
#endregion

//#region 6、绑定配置对象
//{
//    ConfigurationBuilder builder = new ConfigurationBuilder();
//    builder.AddJsonFile("appsettings.json");
//    IConfiguration configuration = builder.Build();

//    AppSettings appSettings = new AppSettings();
//    configuration.GetSection("AppSettings").Bind(appSettings);

//    Console.WriteLine($"ApplicatoinName:{appSettings.ApplicatoinName}");
//    Console.WriteLine($"Version:{appSettings.Version}");

//}


//#endregion

//#region 7、配置选项
//{
//    ConfigurationBuilder builder = new ConfigurationBuilder();
//    builder.AddJsonFile("appsettings.json");
//    IConfiguration configuration = builder.Build();


//    ServiceCollection services = new ServiceCollection();
//    services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

//    var serviceProvider = services.BuildServiceProvider();
//    IOptions<AppSettings> options = serviceProvider.GetRequiredService<IOptions<AppSettings>>();
//    AppSettings appSettings = options.Value;

//    Console.WriteLine($"ApplicatoinName:{appSettings.ApplicatoinName}");
//    Console.WriteLine($"Version:{appSettings.Version}");

//}


//#endregion

#region 8、配置应用
{
    // 1、构造配置对象
    ConfigurationBuilder builder = new ConfigurationBuilder();
    builder.AddJsonFile("appsettings.json", false, true);
    IConfiguration configuration = builder.Build();

    // 2、配置绑定 + 配置对象包装 + 配置对象注册
    ServiceCollection services = new ServiceCollection();
    services.Configure<ProductServiceSettings>(configuration.GetSection("ProductServiceSettings"));
    services.AddSingleton<ProductService>();

    // 3、读取ProductService
    var ServiceProvider = services.BuildServiceProvider();
    ProductService productService = ServiceProvider.GetRequiredService<ProductService>();

    // 4、查询商品
    productService.GetProduct();
    Console.ReadKey();
}
#endregion