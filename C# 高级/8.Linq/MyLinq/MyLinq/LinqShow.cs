using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    /// <summary>
    /// Linq To Object
    /// .NetFramework3.0的一个非常重大的改变
    /// </summary>
    public class LinqShow
    {
        #region Data Init
        private List<Student> GetStudentList()
        {
            #region 初始化数据
            List<Student> studentList = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="赵亮",
                    ClassId=2,
                    Age=35
                },
                new Student()
                {
                    Id=1,
                    Name="再努力一点",
                    ClassId=2,
                    Age=23
                },
                 new Student()
                {
                    Id=1,
                    Name="王炸",
                    ClassId=2,
                    Age=27
                },
                 new Student()
                {
                    Id=1,
                    Name="疯子科学家",
                    ClassId=2,
                    Age=26
                },
                new Student()
                {
                    Id=1,
                    Name="灭",
                    ClassId=2,
                    Age=25
                },
                new Student()
                {
                    Id=1,
                    Name="黑骑士",
                    ClassId=2,
                    Age=24
                },
                new Student()
                {
                    Id=1,
                    Name="故乡的风",
                    ClassId=2,
                    Age=21
                },
                 new Student()
                {
                    Id=1,
                    Name="晴天",
                    ClassId=2,
                    Age=22
                },
                 new Student()
                {
                    Id=1,
                    Name="旭光",
                    ClassId=2,
                    Age=34
                },
                 new Student()
                {
                    Id=1,
                    Name="oldkwok",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="乐儿",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="暴风轻语",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="一个人的孤单",
                    ClassId=2,
                    Age=28
                },
                new Student()
                {
                    Id=1,
                    Name="小张",
                    ClassId=2,
                    Age=30
                },
                 new Student()
                {
                    Id=3,
                    Name="阿亮",
                    ClassId=3,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="37度",
                    ClassId=4,
                    Age=30
                }
                  ,
                  new Student()
                {
                    Id=4,
                    Name="关耳",
                    ClassId=4,
                    Age=30
                }
                  ,
                  new Student()
                {
                    Id=4,
                    Name="耳机侠",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="Wheat",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="Heaven",
                    ClassId=4,
                    Age=22
                },
                  new Student()
                {
                    Id=4,
                    Name="等待你的微笑",
                    ClassId=4,
                    Age=23
                },
                  new Student()
                {
                    Id=4,
                    Name="畅",
                    ClassId=4,
                    Age=25
                },
                  new Student()
                {
                    Id=4,
                    Name="混无痕",
                    ClassId=4,
                    Age=26
                },
                  new Student()
                {
                    Id=4,
                    Name="37度",
                    ClassId=4,
                    Age=28
                },
                  new Student()
                {
                    Id=4,
                    Name="新的世界",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="Rui",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="帆",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="肩膀",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="孤独的根号三",
                    ClassId=4,
                    Age=30
                }
            };
            #endregion
            return studentList;
        }
        #endregion

        public void Show()
        {
            List<Student> studentList = this.GetStudentList();
            //常规情况下数据过滤
            //{
            //    年纪小于30
            //var list = new List<Student>();
            //foreach (var item in studentList)
            //{
            //    if (item.Age < 30)
            //    {
            //        list.Add(item);
            //    }
            //}
            {
                Console.WriteLine("**********************延迟查询*******************");
                var result = studentList.ElevenWhere<Student>(s => s.Age < 30);
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
            }
            {
                Console.WriteLine("********************延时查询*********************");
                var result = studentList.ElevenWhereIterator<Student>(s => s.Age < 30);
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
            }

            //}

            //{
            //    //Name长度大于2的
            //    var list = new List<Student>();
            //    foreach (var item in studentList)
            //    {
            //        if (item.Name.Length > 2)
            //        {
            //            list.Add(item);
            //        }
            //    }

            //    //var result = ExtendMethod.ElevenWhere(studentList, s => s.Name.Length > 2);
            //    var result = studentList.ElevenWhere(s => s.Name.Length > 2);
            //}

            //{
            //    //N个条件叠加
            //    var list = new List<Student>();
            //    foreach (var item in studentList)
            //    {
            //        if (item.Id > 1
            //            && item.Name != null
            //            && item.ClassId == 1
            //            && item.Age > 20)
            //        {
            //            list.Add(item);
            //        }
            //    }
            //    var result = studentList.ElevenWhere(item => item.Id > 1
            //                                            && item.Name != null
            //                                            && item.ClassId == 1
            //                                            && item.Age > 20);
            //}

            //{
            //    new List<int>() { 12423434, 45, 53, 45, 43, 534, 534, 543, 5, 435, 45, 45, }
            //    .ElevenWhere(i => i > 10);
            //}

            //#region Linq 扩展方法&表达式
            //{
            //    var list = studentList.Where<Student>(s => s.Age < 30);//陈述句   言出法随 封装的好
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("Name={0}  Age={1}", item.Name, item.Age);
            //    }
            //}
            //{
            //    Console.WriteLine("********************");
            //    var list = from s in studentList
            //               where s.Age < 30
            //               select s;

            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("Name={0}  Age={1}", item.Name, item.Age);
            //    }
            //}
            //#endregion

            #region linq to object Show
            {
                //这里有一堆学生  每个学生都转换成别的对象

                Console.WriteLine("**********投影**********");
                var list = studentList.Where<Student>(s => s.Age < 30)
                                     .Select(s => new
                                     {
                                         IdName = s.Id + s.Name,
                                         ClassName = s.ClassId == 2 ? "高级班" : "其他班"
                                     });
                foreach (var item in list)
                {
                    Console.WriteLine("Name={0}  Age={1}", item.ClassName, item.IdName);
                }
            }
            {
                Console.WriteLine("********************");
                var list = from s in studentList
                           where s.Age < 30
                           select new
                           {
                               IdName = s.Id + s.Name,
                               ClassName = s.ClassId == 2 ? "高级班" : "其他班"
                           };

                foreach (var item in list)
                {
                    Console.WriteLine("Name={0}  Age={1}", item.ClassName, item.IdName);
                }
            }
            {
                //IN查询
                var list = studentList.Where<Student>(s => s.Age < 30)
                    .Where(s => new int[] { 1, 2, 3, 4 }.Contains(s.ClassId))
                                     .Select(s => new
                                     {
                                         IdName = s.Id + s.Name,
                                         ClassName = s.ClassId == 2 ? "高级班" : "其他班"
                                     });
            }

            {
                Console.WriteLine("********************");
                var list = studentList.Where<Student>(s => s.Age < 30)//条件过滤
                                     .Select(s => new//投影
                                     {
                                         Id = s.Id,
                                         ClassId = s.ClassId,
                                         IdName = s.Id + s.Name,
                                         ClassName = s.ClassId == 2 ? "高级班" : "其他班"
                                     })
                                     .OrderBy(s => s.Id)//排序
                                                        //.ThenBy//2个都生效
                                     .ThenByDescending(s => s.ClassId)//倒排  最后一个生效
                                     .Skip(2)//跳过几条
                                     .Take(3)//获取几条
                                     ;
                foreach (var item in list)
                {
                    Console.WriteLine($"Name={item.ClassName}  Age={item.IdName}");
                }
            }
            {
                var list = from s in studentList
                           where s.Age < 30
                           group s by s.ClassId into sg
                           select sg;
                foreach (var data in list)
                {
                    Console.WriteLine(data.Key);
                    foreach (var item in data)
                    {
                        Console.WriteLine($"{item.Id} {item.Name} {item.Age}");
                    }
                }
            }
            {//group by
                Console.WriteLine("********************");
                var list = from s in studentList
                           where s.Age < 30
                           group s by s.ClassId into sg
                           select new
                           {
                               key = sg.Key,
                               maxAge = sg.Max(t => t.Age)
                           };
                foreach (var item in list)
                {
                    Console.WriteLine($"key={item.key}  maxAge={item.maxAge}");
                }
                //group by new {s.ClassId,s.Age}
                //group by new {A=s.ClassId>1}
            }
            {
                //var list = studentList.GroupBy(s => new { s.ClassId, s.Age }).Select(sg => new
                //{
                //    key = sg.Key,
                //    maxAge = sg.Max(t => t.Age)
                //});
                //foreach (var item in list)
                //{
                //    item.ke
                //}
            }
            {
                Console.WriteLine("********************");
                var list = studentList.GroupBy(s => s.ClassId).Select(sg => new
                {
                    key = sg.Key,
                    maxAge = sg.Max(t => t.Age)
                });
                foreach (var item in list)
                {
                    Console.WriteLine($"key={item.key}  maxAge={item.maxAge}");
                }
            }
            List<Class> classList = new List<Class>()
                {
                    new Class()
                    {
                        Id=1,
                        ClassName="初级班"
                    },
                    new Class()
                    {
                        Id=2,
                        ClassName="高级班"
                    },
                    new Class()
                    {
                        Id=3,
                        ClassName="微信小程序"
                    },
                };
            {
                var list = from s in studentList
                           join c in classList on s.ClassId equals c.Id//不能用==只能equals
                           select new
                           {
                               Name = s.Name,
                               CalssName = c.ClassName
                           };
                foreach (var item in list)
                {
                    Console.WriteLine($"Name={item.Name},CalssName={item.CalssName}");
                }
            }
            {
                var list = studentList.Join(classList, s => s.ClassId, c => c.Id, (s, c) => new
                {
                    Name = s.Name,
                    CalssName = c.ClassName
                });
                foreach (var item in list)
                {
                    Console.WriteLine($"Name={item.Name},CalssName={item.CalssName}");
                }
            }
            {//左连接
                var list = from s in studentList
                           join c in classList on s.ClassId equals c.Id
                           into scList
                           from sc in scList.DefaultIfEmpty()//
                           select new
                           {
                               Name = s.Name,
                               CalssName = sc == null ? "无班级" : sc.ClassName//c变sc，为空则用
                           };
                foreach (var item in list)
                {
                    Console.WriteLine($"Name={item.Name},CalssName={item.CalssName}");
                }
                Console.WriteLine(list.Count());
            }
            {
                var list = studentList.Join(classList, s => s.ClassId, c => c.Id, (s, c) => new
                {
                    Name = s.Name,
                    CalssName = c.ClassName
                }).DefaultIfEmpty();//为空就没有了
                foreach (var item in list)
                {
                    Console.WriteLine($"Name={item.Name},CalssName={item.CalssName}");
                }
                Console.WriteLine(list.Count());
            }
            {
                //Min  Max  Sum  
            }
            #endregion

            {
                //linq to sql
                IQueryable<Student> list = studentList.AsQueryable();
                list.Where<Student>(s => s.Age > 30);//操作数据库
                //list.Where<Student>(s =>
                //{
                //    Console.WriteLine("12354");
                //    return s.Age > 30;
                //});
            }
            {
                studentList.Where<Student>(s =>
                {
                    Console.WriteLine("12354");
                    return s.Age > 30;
                }
                );
            }
        }

    }
}
