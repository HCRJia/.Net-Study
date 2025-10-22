using MyAttribute;

namespace MyAttribute
{
    [Custom(123, Remark = "VIP", Description = "VIP学员")]
    [Serializable]
    public class StudentVip : Student
    {
        [Custom(123, Remark = "VIP", Description = "VIP学员")]
        public string VipGroup { get; set; }

        [Custom(123, Remark = "VIP", Description = "VIP学员")]
        public void Homework()
        {
            Console.WriteLine("Homework");
        }


    }
}
