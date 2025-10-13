namespace Work
{
    public static class Framwork
    {
        public static void Show<T>(this T t)
        {

            Type type = t.GetType();
            foreach(var prop in type.GetProperties())
            {
                Console.WriteLine($"{prop.Name}:{prop.GetValue(t)}");
            }

        }
    }
}
