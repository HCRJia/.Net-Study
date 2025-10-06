using Generic;
using Generic.Extend;
using MyGeneric;
using System;

int iValue = 123;
string sValue = "456";
DateTime dtValue = DateTime.Now;
object oValue = "678";

//Console.WriteLine("***********************Common***********************");
//CommonMethod.ShowInt(iValue);
////CommonMethod.ShowInt(sValue);
//CommonMethod.ShowString(sValue);
//CommonMethod.ShowDateTime(dtValue);

//Console.WriteLine("***********************Object***********************");
//CommonMethod.ShowObject(iValue);
//CommonMethod.ShowObject(sValue);
//CommonMethod.ShowObject(dtValue);

//Console.WriteLine("***********************Generic***********************");
//CommonMethod.Show<int>(iValue);//调用泛型，需要指定类型参数
////CommonMethod.Show(iValue);//如果可以从参数类型推断，可以省略类型参数---语法糖(编译器提供的功能)
//CommonMethod.Show<string>(sValue);
////CommonMethod.Show<int>(sValue);//报错，因为类型错了
//CommonMethod.Show<DateTime>(dtValue);
//Console.WriteLine("****************Monitor******************");
//for (int i = 0; i < 10; i++) { Generic.Monitor.Show(); }

// T是int类型
//GenericClass<int> genericInt = new GenericClass<int>();
//genericInt._T = 123;
//// T是string类型
//GenericClass<string> genericString = new GenericClass<string>();
//genericString._T = "123";

People people = new People()
{
    Id = 123,
    Name = "Mike"
};
Chinese chinese = new Chinese()
{
    Id = 234,
    Name = "张三"
};
ZheJiang zhejiang = new ZheJiang()
{
    Id = 345,
    Name = "李四"
};
Japanese japanese = new Japanese()
{
    Id = 456,
    Name = "路飞"
};

//GenericConstraint.ShowObject(people);
//GenericConstraint.ShowObject(chinese);
//GenericConstraint.ShowObject(zhejiang);

int num = 123;
//GenericConstraint.ShowObject(123);

GenericConstraint.Show<People>(people);
GenericConstraint.Show<Chinese>(chinese);
GenericConstraint.Show<ZheJiang>(zhejiang);
//GenericConstraint.Show<int>(num);

CCTest.Show();


