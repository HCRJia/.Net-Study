
using MyDelegate;

MyDelegateUse myDelegate = new MyDelegateUse();
myDelegate.DelegateUse();

{
    Student student = new Student()
    {
        Id = 123,
        Name = "张三",
        Age = 23,
        ClassId = 1
    };
    //上端还不是得知道是哪个国家的人？
    student.Study();
    student.SayHi("大脸猫", PeopleType.Chinese);

    student.SayHi("icefoxz", PeopleType.Malaysia);

    student.SayHiChinese("大脸猫");

    {
        SayHiDelegate method = new SayHiDelegate(student.SayHiChinese);
        student.SayHiPerfact("张三", method);
    }
    {
        SayHiDelegate method = new SayHiDelegate(student.SayHiAmerican);
        student.SayHiPerfact("PHS", method);
    }
    {
        SayHiDelegate method = new SayHiDelegate(student.SayHiMalaysia);
        student.SayHiPerfact("icefoxz", method);
    }
}