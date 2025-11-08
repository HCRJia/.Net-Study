Linq是一个查询用的表达式，那为什么需要Linq呢，我们可以来看看不用Linq的查询

# 场景

我们先创建一个List<Student> studentList，下面是Student类的声明：

```csharp
public class Student
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
```

当我们查询年龄小于30的时候，最简单的方法是用for循环：

```csharp
var list = new List<Student>();
foreach (var item in studentList)
{
    if (item.Age < 30)
    {
        list.Add(item);
    }
}
```

当然，如果需要提高可读性，可以将筛选的方法拎出来，写成函数。筛选的条件作为参数传进去，怎么传呢？可以使用Lambda表达式，那么参数就要定义成返回值为bool的委托：

```csharp
public static List<T> ElevenWhere<T>(this List<T> resource, Func<T, bool> func)
{
    var list = new List<T>();
    foreach (var item in resource)
    {
        if (func.Invoke(item))
        {
            list.Add(item);
        }
    }
    return list;
}
```

这里面ElevenWhere是个扩展类，可以使用类名.ElevenWhere 来调用，func是个泛型委托，需要传一个方法，这里传Lambda表达式，函数内就是正常的for循环处理。这样一来，上面的查询可以直接改成一句话：

```csharp
var result = studentList.ElevenWhere<Student>(s => s.Age < 30);
```

这里的result就是结果集。上面的方法可以提供简单的条件查询，那么对于复杂点的查询呢，又需要重新写查询语句再封装，那么，不如直接使用已经封装好的功能。Linq就提供了封装好的查询，可以进行复杂查询

# Linq简介

LINQ（Language Integrated Query）是**语言集成查询**。它是一套统一的编程模型，允许你用相同的语法查询多种数据源。Linq可以查询多种数据源：

Linq To Object：在Enumerable类，针对IEnumerable数据进行一系列的查询，通常的类都在内。

Linq To Sql：LINQ to SQL 是一个ORM框架，它可以将LINQ查询转换为SQL语句并通过ADO.NET执行。

Linq To XML：对XML文件的查询

Linq to json：对json的查询

等等

下面主要是对Linq To Object进行Linq语法的讲解，对于其它的使用语法上类似。

# Linq使用

## 查询

对于上面的例子，Linq的写法如下：

```csharp
var list = from s in studentList
           where s.Age < 30
           select new
           {
               IdName = s.Id + s.Name,
               ClassName = s.ClassId == 2 ? "高级班" : "其他班"
           };
```

linq的基本格式是

`from source in collection`：指定查询的数据源

`where condition`：指定筛选条件。

`select result`：定义查询结果

select后面是一个匿名类，里面是IdName和ClassName字段，因此list也只有这两个字段。

除了这种写法外，linq还支持和Lambda表达式一起用：

```csharp
var list = studentList.Where<Student>(s => s.Age < 30)
                     .Select(s => new
                     {
                         IdName = s.Id + s.Name,
                         ClassName = s.ClassId == 2 ? "高级班" : "其他班"
                     });
                     .OrderBy(s => s.Id)//排序
                     .ThenByDescending(s => s.ClassId)//倒排  最后一个生效
                     .Skip(2)//跳过几条
                     .Take(3)//获取几条
```

这里除了where外，还提供了排序和分页查询的功能。

## 分组

Linq可以实现SQL里GROUP BY的功能，需要和聚合函数一起使用，写法如下：

```csharp
var list = from s in studentList
           where s.Age < 30
           group s by s.ClassId into sg
           select new
           {
               key = sg.Key,
               maxAge = sg.Max(t => t.Age)
           };
var list = studentList.GroupBy(s => s.ClassId).Select(sg => new
{
    key = sg.Key,
    maxAge = sg.Max(t => t.Age)
});
```

上面同时提供有无Lambda表达式的语句

## 连接

Linq还可以实现SQL里的连接功能，join类似与内连接，为了实现内连接，新实现了一个类classList

```csharp
var list = from s in 
           join c in classList on s.ClassId equals c.Id
           into scList
           from sc in scList.DefaultIfEmpty()//
           select new
           {
               Name = s.Name,
               CalssName = sc == null ? "无班级" : sc.ClassName//c变sc，为空则用
           };
```

在上面的写法中，连接时需要使用equals而不是==

```csharp
var list = studentList.Join(classList, s => s.ClassId, c => c.Id, (s, c) => new
{
    Name = s.Name,
    CalssName = c.ClassName
}).DefaultIfEmpty();//为空就没有了
```

# 延迟执行

Linq还有一个重要的特性：延迟查询。如上面的例子，当写完Linq语句并赋值给list时，不会立即执行这段代码，而是在之后的for调用list时运行代码。

我们可以试着给ElevenWhere加上输出语句调试。

```csharp
public static List<T> ElevenWhere<T>(this List<T> resource, Func<T, bool> func)
{
    var list = new List<T>();
    foreach (var item in resource)
    {
        Console.WriteLine("进入数据检测");
        Thread.Sleep(100);
        if (func.Invoke(item))
        {
            list.Add(item);
        }
    }
    return list;
}
var result = studentList.ElevenWhere<Student>(s => s.Age < 30);
foreach (var item in result)
{
    Console.WriteLine(item.Name);
}
```

执行代码后，运行结果如下：

![img](https://cdn.nlark.com/yuque/0/2025/png/42432244/1762527494208-2d855150-aebe-497c-b953-4c31a6d4a9dd.png)

可以看到，上面是执行完所有的查询，foreach时输出所有的结果，再来下面的例子：

```csharp
public static IEnumerable<T> ElevenWhereIterator<T>(this IEnumerable<T> resource, Func<T, bool> func)
{
    foreach (var item in resource)
    {
        Console.WriteLine("进入数据检测");
        Thread.Sleep(100);
        if (func.Invoke(item))
        {
            yield return item;//yield 跟IEnumerable配对使用
        }
    }
}
var result = studentList.ElevenWhereIterator<Student>(s => s.Age < 30);
foreach (var item in result)
{
    Console.WriteLine(item.Name);
}
```

  ![img](https://cdn.nlark.com/yuque/0/2025/png/42432244/1762527501706-9a60abb1-e3a0-4d2d-b601-c034398986ed.png)

可以看到，这里的输出和进入数据检测是交错着的，意味着foreach再进行查询。这就是延迟执行。

延迟执行能够更好的提升程序性能，这也是Linq的优势之一。