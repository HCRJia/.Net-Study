//1 建立一个数据库，然后执行下面的数据库脚本，会增加两张表 User Company，大家可以去表里面自己多加入一些数据

//2 建立数据库表映射的基类BaseModel，包括 Id属性
//  建立两个子类Model：公司和用户，按照表结构来

//3 提供两个泛型的数据库访问方法，用 BaseModel约束
//一个是用id去查询单个实体，(只有这一个参数)
//一个是查询出数据表的全部数据列表查询(没有参数)

//提示：用DataReader去访问数据库，将得到的结果通过反射生成实体对象/集合返回；

//4 封装一个方法，能控制台输出任意实体的全部属性和属性值；

//5 进阶需求：提供泛型的数据库实体插入、实体更新、ID删除数据的数据库访问方法；

//6 进阶需求（可选）：欢迎小伙伴儿写个实体自动生成器；

//7 进阶需求（可选）：将数据访问层抽象，使用简单工厂+配置文件+反射的方式，来提供对数据访问层的使用

//8 进阶需求（可选）：每个实体类的基础增删改查SQL语句是不变的，用泛型缓存试试！
using DAL;
using Work;

Console.WriteLine("Hello, World!");

BaseDAL baseDAL = new BaseDAL();
baseDAL.FindAllT<Model.User>();

var u = baseDAL.FindT<Model.User>(1);

Framwork.Show<Model.User>(u);
