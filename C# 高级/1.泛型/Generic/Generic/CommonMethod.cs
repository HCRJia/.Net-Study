namespace Generic
{
    public class CommonMethod
    {

        /// <summary>
        /// 打印个int值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, iParameter.GetType().Name, iParameter);
        }
        /// <summary>
        /// 打印个string值
        /// </summary>
        /// <param name="sParameter"></param>
        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, sParameter.GetType().Name, sParameter);
        }
        /// <summary>
        /// 打印个DateTime值
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, dtParameter.GetType().Name, dtParameter);
        }

        /// <summary>
        /// 打印个object值
        /// 1 任何父类出现的地方，都可以用子类来代替
        /// 2 object是一切类型的父类
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), oParameter.GetType().Name, oParameter);
        }

        /// <summary>
        /// 使用泛型
        /// T可以是任何类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)//, T t = default(T
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
               typeof(CommonMethod), tParameter.GetType().Name, tParameter);
        }
    }
}
