using MyAttribute;

//{
//    Student student = new Student()
//    {
//        Id = 123,
//        Name = "张三"
//    };
//    student.Study();
//    student.Answer("答案");

//}

Student student = new StudentVip()
{
    Id = 123,
    Name = "Alxe"
};
InvokeCenter.ManagerStudent<Student>(student);