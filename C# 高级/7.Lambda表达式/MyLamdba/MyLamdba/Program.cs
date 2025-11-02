using MyLamdba;

/// <summary>
/// 1 匿名方法 lambda表达式 
/// 2 匿名类 var 扩展方法
{
    //Console.WriteLine("***************Lambda*****************");
    LambdaShow lambdaShow = new LambdaShow();
    lambdaShow.Show();
}

#region 3.0出了个匿名类 var
//{
//    Console.WriteLine("*****************匿名类**************");
//    Student student = new Student()
//    {
//        Id = 1,
//        Name = "斤宝PAPI",
//        Age = 25,
//        ClassId = 2
//    };
//    student.Study();

//    //匿名类
//    //object model = new //3.0
//    //{
//    //    Id = 2,
//    //    Name = "undefined",
//    //    Age = 25,
//    //    ClassId = 2,
//    //    Teacher="Eleven"
//    //};
//    //Console.WriteLine(model.Id);
//    //Console.WriteLine(model, Name); 
//    //C#强类型语言，编译时会确定类型，object 决定了没有Id属性  
//    //运行时确实有Id和Name  但是编译器不认可

//    //dynamic避开编译器检查
//    //dynamic dModel = new//4.0
//    //{
//    //    Id = 2,
//    //    Name = "undefined",
//    //    Age = 25,
//    //    ClassId = 2
//    //};
//    //Console.WriteLine(dModel.Id);
//    //Console.WriteLine(dModel.Name);
//    ////dModel.Study();
//    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
var model = new //3.0
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
//    //model.Id = 3;//只读  只有初始化的时候指定

//    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
//    int i2 = 2;
//    var i1 = 1;//var就是个语法糖，由编译器自动推算
//    var s = "Eleven";
//    //var aa;//var声明的变量必须初始化，必须能推算出类型

//    ////1 var 配合匿名类型使用
//    ////2 var 偷懒，复杂类型的使用
//}
#endregion

#region 扩展方法 3.0
{
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
    ////扩展方法调用，很像实例方法，就像扩展了Student的逻辑
    ////1 第三方的类，不适合修改源码，可以通过扩展方法增加逻辑
    ////优先调用实例方法，最怕扩展方法增加了，别人类又修改了
    ////2 适合组件式开发的扩展(.NetCore)，定义接口或者类，是按照最小需求，但是在开发的时候又经常需要一些方法，就通过扩展方法 context.Response.WriteAsync  中间件的注册
    ////3 扩展一些常见操作
    ////会污染基础类型，一般少为object  没有约束的泛型去扩展
    //int? k = 23;
    //int l = 4;
    //int r = k.ToInt() + l;
    //string result = "2342543546546464564656".ToLength(20);

    //k.ToStringCustom();
    //l.ToStringCustom();
    //result.ToStringCustom();
    //object o = "";
    ////o.
    ////k.

}
#endregion