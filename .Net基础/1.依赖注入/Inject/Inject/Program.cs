using Inject.Inject;
using Microsoft.Extensions.DependencyInjection;

#region 1、单例
{
    /*// 1、创建依赖注入（IOC容器）
    ServiceCollection services = new ServiceCollection();

    // 2、注册ProductService
    services.AddSingleton<ProductService>();
    // 2.1、注册ProductRepository
    services.AddSingleton<ProductRepository>();

    // 3、取对象（构造ServiceProvider）
    var ServiceProvider = services.BuildServiceProvider();

    // 4、取对象
    ProductService productService = ServiceProvider.GetRequiredService<ProductService>();
    productService.GetProduct();

    // 4、取对象(验证单例)
    ProductService productService1 = ServiceProvider.GetRequiredService<ProductService>();
    productService1.GetProduct();*/
}
#endregion

#region 2、Transient
{
    //// 1、创建依赖注入（IOC容器）
    //ServiceCollection services = new ServiceCollection();

    //// 2、注册ProductService
    //services.AddTransient<ProductService>();
    //// 2.1、注册ProductRepository
    //services.AddTransient<ProductRepository>();

    //// 3、取对象（构造ServiceProvider）
    //var ServiceProvider = services.BuildServiceProvider();

    //// 4、取对象
    //ProductService productService = ServiceProvider.GetRequiredService<ProductService>();
    //productService.GetProduct();

    //// 4、取对象(验证单例)
    //ProductService productService1 = ServiceProvider.GetRequiredService<ProductService>();
    //productService1.GetProduct();
}
#endregion

#region 3、Scope
{
    /*// 1、创建依赖注入（IOC容器）
    ServiceCollection services = new ServiceCollection();

    // 2、注册ProductService
    services.AddScoped<IProductService,ProductService>();
    // 2.1、注册ProductRepository
    services.AddScoped<IProductRepository,ProductRepository>();

    // 3、取对象（构造ServiceProvider）
    var ServiceProvider = services.BuildServiceProvider();

    // 4、取对象
    using (IServiceScope serviceScope = ServiceProvider.CreateScope()) 
    {
        // 1、第一次
        IProductService productService = serviceScope.ServiceProvider.GetRequiredService<IProductService>();
        productService.GetProduct();

        // 1、第一次
        IProductService productService1 = serviceScope.ServiceProvider.GetRequiredService<IProductService>();
        productService1.GetProduct();
    }

    using (IServiceScope serviceScope = ServiceProvider.CreateScope())
    {
        // 1、第一次
        IProductService productService = serviceScope.ServiceProvider.GetRequiredService<IProductService>();
        productService.GetProduct();

        // 1、第一次
        IProductService productService1 = serviceScope.ServiceProvider.GetRequiredService<IProductService>();
        productService1.GetProduct();
    }*/

}
#endregion

#region 4、多实现类
{
    // 1、创建依赖注入（IOC容器）
    ServiceCollection services = new ServiceCollection();

    // 2、注册ProductService
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<IProductService, CSProductService>();
    // 2.1、注册ProductRepository
    services.AddScoped<IProductRepository, ProductRepository>();

    // 3、取对象（构造ServiceProvider）
    var ServiceProvider = services.BuildServiceProvider();

    // 4、取对象
    using (IServiceScope serviceScope = ServiceProvider.CreateScope())
    {

        IProductService productService = serviceScope.ServiceProvider.GetRequiredService<IProductService>();
        productService.GetProduct();


        IProductService productService1 = serviceScope.ServiceProvider.GetRequiredService<IProductService>();
        productService1.GetProduct();

        // 2、取多个实现类
        IEnumerable<IProductService> productServices = serviceScope.ServiceProvider.GetServices<IProductService>();
        foreach (var productService in productServices)
        {
            productService.GetProduct();
        }

    }
}
#endregion