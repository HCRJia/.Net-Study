using Generic;

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
GenericClass<int> genericInt = new GenericClass<int>();
genericInt._T = 123;
// T是string类型
GenericClass<string> genericString = new GenericClass<string>();
genericString._T = "123";