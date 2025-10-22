namespace MyAttribute
{
    /// <summary>
    /// 这里是注释，除了让人看懂这里写的是什么，
    /// 对运行没有任何影响
    /// </summary>
    //[Obsolete("请不要使用这个了，请使用什么来代替", true)]
    [Serializable]//可以序列化和反序列化

    [Custom]
    [Custom(0)]
    [Custom(0, Remark = "123")]
    [Custom(0, Remark = "123", Description = "456")]
    public class Student
    {
        [Custom]
        public int Id { get; set; }
        public string Name { get; set; }
        [Custom]
        public void Study()
        {
            Console.WriteLine($"我是{this.Name}");
        }

        [return: Custom, Custom,Custom(), Custom(0, Remark = "123", Description = "456")]
        [Custom(0)]
        [Custom(0, Remark = "123")]
        [Custom(0, Remark = "123", Description = "456")]
        public string Answer([Custom]string name)
        {
            return $"This is {name}";
        }
    }
}
