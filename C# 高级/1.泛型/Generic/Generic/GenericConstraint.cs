namespace MyGeneric
{
    /// <summary>
    /// 泛型约束
    /// </summary>
    public class GenericConstraint
    {
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericConstraint), oParameter.GetType().Name, oParameter);
            People people = (People)oParameter;
            Console.WriteLine($"{people.Id}  {people.Name}");
        }


        /// <summary>
        /// 没有约束，其实很受局限
        /// where T:BaseModel
        /// 基类约束：
        /// 1 可以把T当成基类---权利
        /// 2 T必须是People或者其子类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
            where T : People

        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
               typeof(GenericConstraint), tParameter.GetType().Name, tParameter);

            Console.WriteLine($"{tParameter.Id}  {tParameter.Name}");
        }

        public static void ShowPeople(People people)
        {
            Console.WriteLine($"{people.Id}  {people.Name}");
            people.Hi();
        }


        public T GetT<T, S>()
            where T : class//引用类型约束
            where S : class
        {
            return null;
        }
    }
}
