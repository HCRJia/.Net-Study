using System;
using System.Reflection;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 使用 DispatchProxy 在 .NET Core/.NET 8 上实现动态代理（替代 .NET Remoting/RealProxy）
    /// 适用于基于接口的代理，不需要 MarshalByRefObject
    /// </summary>
    public class RealProxyAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Eleven",
                Password = "123456"
            };

            // 直接使用真实实现
            UserProcessor processor = new UserProcessor();
            processor.RegUser(user);

            Console.WriteLine("*********************");

            // 使用 DispatchProxy 创建接口代理（接口类型用来引用）
            IUserProcessor userProcessor = TransparentProxy.Create<IUserProcessor, UserProcessor>();
            userProcessor.RegUser(user);
        }

        /// <summary>
        /// DispatchProxy 拦截器（通用）
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        public class Interceptor<TInterface> : DispatchProxy where TInterface : class
        {
            public TInterface Target { get; set; } = default!;

            protected override object? Invoke(MethodInfo targetMethod, object?[] args)
            {
                BeforeProceed(targetMethod, args);

                // 调用真实对象方法
                object? result = targetMethod.Invoke(Target, args);

                AfterProceed(targetMethod, args);

                return result;
            }

            private void BeforeProceed(MethodInfo method, object?[] args)
            {
                Console.WriteLine($"[Before] 调用方法: {method.Name}");
            }

            private void AfterProceed(MethodInfo method, object?[] args)
            {
                Console.WriteLine($"[After] 调用方法: {method.Name}");
            }
        }

        /// <summary>
        /// 透明代理工厂：创建接口代理并内部实例化具体实现
        /// 用法：TransparentProxy.Create&lt;IUserProcessor, UserProcessor&gt;()
        /// </summary>
        public static class TransparentProxy
        {
            public static TInterface Create<TInterface, TImplementation>()
                where TInterface : class
                where TImplementation : TInterface, new()
            {
                // 创建真实实现
                TImplementation instance = new TImplementation();

                // 创建代理并注入真实实现
                TInterface proxy = DispatchProxy.Create<TInterface, Interceptor<TInterface>>();
                (proxy as Interceptor<TInterface>)!.Target = instance;

                return proxy;
            }
        }


        public interface IUserProcessor
        {
            void RegUser(User user);
        }

        /// <summary>
        /// 真实实现：不需要继承 MarshalByRefObject
        /// </summary>
        public class UserProcessor : IUserProcessor
        {
            public void RegUser(User user)
            {
                Console.WriteLine("用户已注册。用户名称{0} Password{1}", user.Name, user.Password);
            }
        }

    }
}