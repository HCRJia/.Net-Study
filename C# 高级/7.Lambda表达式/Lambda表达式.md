# Lamdba是什么

`Lambda` 表达式是 `C#` 中简洁表达匿名方法的一种方式，是一个语法糖，常用于函数式编程风格。`Lambda` 的本质其实是一个匿名方法。

# Lamdba使用

## 匿名方法

```csharp
{
    //lambda表达式  参数列表=>方法体
    NoReturnWithPara method = new NoReturnWithPara(
        (int id, string name) =>
        {
            Console.WriteLine($"{id} {name} 学习.Net");
        });
    method.Invoke(123, "王五");
}
{
    NoReturnWithPara method = new NoReturnWithPara(
        (id, name) =>//省略参数类型，编译器的语法糖，虽然没写，编译时还是有的，根据委托推算
        {
            Console.WriteLine($"{id} {name} 学习.Net");
        });
    method.Invoke(123, "赵六");
}
{
    NoReturnWithPara method = new NoReturnWithPara(
        (id, name) => Console.WriteLine($"{id} {name} 学习.Net"));
    //如果方法体只有一行，可以去掉大括号和分号
    method.Invoke(123, "甲");
}
{
    NoReturnWithPara method = (id, name) => Console.WriteLine($"{id} {name} 学习.Net");
    method.Invoke(123, "乙"); //new NoReturnWithPara可以省掉，也是语法糖，编译器自动加上
}
```

写了通过Lamdba表达式定义的委托，一步一步简化，最终变成(parameter_list) => expression的语句。这个语句左边是参数列表，右边是表达式，中间用=>来连接，在编译后，这条语句会编译成匿名方法。

当然，Lamdba也可以用在有返回值的方法：

```csharp
Func<int> func0 = () => DateTime.Now.Month;
int iResult = func0.Invoke();
Console.WriteLine("返回值：" + iResult);
```

用委托来接收方法，执行委托便可获取返回值

## 匿名类

Lamdba表达式是一个匿名方法，匿名类也可以拿来一块讲，下面就是匿名类的一种使用：

```csharp
var model = new 
{
    Id = 2,
    Name = "张三",
    Age = 25,
    ClassId = 2,
    Teacher = "李四"
};
Console.WriteLine(model.Id);
Console.WriteLine(model.Teacher);
Console.WriteLine(model.GetType().Name);
```

匿名类就是无需声明类，直接使用var来声明，当运行后的输出如下：

![img](https://cdn.nlark.com/yuque/0/2025/png/42432244/1762068405510-327dd1c5-34f3-4f05-aeb5-25c813f781e8.png)

编译器生成了一个类，放了这5个属性，属性类型是由编译器自己推的。如果有些类只用到一次，那么完全可以用匿名类，var是一个语法糖，不只用来定义类，对于基本类型也能用var定义，如 var num = 1 ，编译器会判断这个num是int类型。model的属性是只读的，如果还想后续修改model的属性，那么就不能使用匿名类。

## 扩展方法

扩展方法，就是不修改类的情况下，扩展方法来增加逻辑。

```csharp
public class Student
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public void Study()
    {
        Console.WriteLine("{0} {1}学习.net高级开发", this.Id, this.Name);
    }

    public void StudyHard()
    {
        Console.WriteLine("{0} {1}努力学习.net高级开发", this.Id, this.Name);
    }

}
public static class ExtendMethod
{

    public static void StudyPractise(this Student student)
    {
        Console.WriteLine("{0} {1}学习.net实战开发", student.Id, student.Name);
    }

}
```

准备了Student类，然后再写一个扩展方法StudyPractise放在其他地方，扩展方法就是静态类里面的静态方法，第一个参数类型前面加上this。

```csharp
Student student = new Student()
{
    Id = 1,
    Name = "张三",
    Age = 25,
    ClassId = 2
};
student.Study();
ExtendMethod.StudyPractise(student);
student.StudyPractise();
```

​	这里StudyPractise就是扩展方法的调用，跟普通方法不同的是扩展方法可以直接写成student.StudyPractise()，就像StudyPractise是属于Student的方法一样。如果类里添加了某个方法，又写了相同的扩展方法，那么会优先调用实例方法。