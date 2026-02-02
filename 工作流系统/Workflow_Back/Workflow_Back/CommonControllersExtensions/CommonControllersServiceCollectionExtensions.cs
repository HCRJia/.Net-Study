using Workflow_Back.CommonExceptions;
using Workflow_Back.CommonResults;

namespace Workflow_Back.CommonControllersExtensions
{
    /// <summary>
    /// CommonController模块封装
    /// </summary>
    public static class CommonControllersServiceCollectionExtensions
    {
        /// <summary>
        /// 1、实现CommonController模块
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCommonControllers(this IServiceCollection services)
        {
            services.AddControllers(options => {
                // 1、配置CommonResultFilter
                options.Filters.Add<CommonResultFilter>();
                // 2、配置CommonExceptionFilter
                options.Filters.Add<CommonExceptionFilter>();
            }).AddJsonOptions(options => {
                // 3、配置通用Json格式
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            return services;
        }
    }
}
