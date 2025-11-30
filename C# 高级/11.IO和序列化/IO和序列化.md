IO和序列化都是项目中常用的功能，IO是磁盘文件读写，一般会用来处理文件，序列化是把对象等转换成json字符串，也可以把json字符串转换成对象。

# IO的使用

先通过配置项声明一个绝对路径或相对路径：

```csharp
<add key="LogPath" value="D:\Code\.Net Study\C# 高级\11.IO和序列化\IOSerialize\IOSerialize\Log\"/>
<add key="LogMovePath" value="D:\Code\.Net Study\C# 高级\11.IO和序列化\IOSerialize\IOSerialize\LogMove\"/>
<add key="ImagePath" value="D:\Code\.Net Study\C# 高级\11.IO和序列化\IOSerialize\IOSerialize\Image\"/>
```

IO的文件夹类是DirectoryInfo类，文件的类是File类。

## DirectoryInfo类

```csharp
if (!Directory.Exists(LogPath))//检测文件夹是否存在
{
}
DirectoryInfo directory = new DirectoryInfo(LogPath);//不存在不报错  注意exists属性
Console.WriteLine(string.Format("{0} {1} {2}", directory.FullName, directory.CreationTime, directory.LastWriteTime));

if (!File.Exists(Path.Combine(LogPath, "info.txt")))
{
}

FileInfo fileInfo = new FileInfo(Path.Combine(LogPath, "info.txt"));

Console.WriteLine(string.Format("{0} {1} {2}", fileInfo.FullName, fileInfo.CreationTime, fileInfo.LastWriteTime));
```

这块代码就是通过路径去获取文件夹和文件，然后展示两个类的FullName，CreationTime，LastWriteTime属性。这里需要注意，直接用DirectoryInfo(地址)来获取是有问题了，不管该地址存不存在都不会报错，所以需要通过Directory.Exists(LogPath)来判断路径是否存在，FileInfo同理。

```csharp
DirectoryInfo directoryInfo = Directory.CreateDirectory(LogPath);//一次性创建全部的子路径
Directory.Move(LogPath, LogMovePath);//移动  原文件夹就不在了
Directory.Delete(LogMovePath);//删除
```

上面是文件夹创建，移动，删除的方法。

除了这些，还有：

获取当前目录下的所有子目录方法：Directory.GetDirectories

获取当前目录下的所有文件方法：Directory.GetFiles

等等

## File类

```csharp
 string fileName = Path.Combine(LogPath, "log.txt");
 string fileNameCopy = Path.Combine(LogPath, "logCopy.txt");
 string fileNameMove = Path.Combine(LogPath, "logMove.txt");
 bool isExists = File.Exists(fileName);
 if (!isExists)
 {
     Directory.CreateDirectory(LogPath);//创建了文件夹之后，才能创建里面的文件
    using (FileStream fileStream = File.Create(fileName))//打开文件流 （创建文件并写入）
    {
        string name = "12345567778890";
        byte[] bytes = Encoding.Default.GetBytes(name);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Flush();
    }
    using (FileStream fileStream = File.Create(fileName))//打开文件流 （创建文件并写入）
    {
        StreamWriter sw = new StreamWriter(fileStream);
        sw.WriteLine("12345567778890");
        sw.Flush();
    }

    using (StreamWriter sw = File.AppendText(fileName))//流写入器（创建/打开文件并写入）
    {
        string msg = "12345567778890";
        sw.WriteLine(msg);
        sw.Flush();
    }
    using (StreamWriter sw = File.AppendText(fileName))//流写入器（创建/打开文件并写入）
    {
        string name = "12345567778890";
        byte[] bytes = Encoding.Default.GetBytes(name);
        sw.BaseStream.Write(bytes, 0, bytes.Length);
        sw.Flush();
    }


     foreach (string result in File.ReadAllLines(fileName))
     {
         Console.WriteLine(result);
     }
     string sResult = File.ReadAllText(fileName);
     Byte[] byteContent = File.ReadAllBytes(fileName);
     string sResultByte = System.Text.Encoding.UTF8.GetString(byteContent);

     using (FileStream stream = File.OpenRead(fileName))//分批读取
     {
         int length = 5;
         int result = 0;

         do
         {
             byte[] bytes = new byte[length];
             result = stream.Read(bytes, 0, 5);
             for (int i = 0; i < result; i++)
             {
                 Console.WriteLine(bytes[i].ToString());
             }
         }
         while (length == result);
     }

     File.Copy(fileName, fileNameCopy);
     File.Move(fileName, fileNameMove);
     File.Delete(fileNameCopy);
     File.Delete(fileNameMove);//尽量不要delete
 }
```

上面是FileInfo对文件的操作：

首先是通过FileStream或StreamWriter开启文件流，FileStream可以用来创建文件，StreamWriter可以用来对文件进行写入。并写了转换成字节写入和直接写入的操作。开启文件流时，无法再打开文件，会显示文件被占用。

File.ReadAllLines，File.ReadAllText，File.ReadAllBytes就是读取文件内容的操作。

当文件太大时，就无法使用上面的方法进行读取了，大文件读取时会占用大量内存，不适合直接读，可以用分批读取的方式去读取文件。

File.Copy就是复制一份文件，File.Move是删除源文件，复制新文件。

```csharp
DriveInfo[] drives = DriveInfo.GetDrives();

foreach (DriveInfo drive in drives)
{
    if (drive.IsReady)
        Console.WriteLine("类型：{0} 卷标：{1} 名称：{2} 总空间：{3} 剩余空间：{4}", drive.DriveType, drive.VolumeLabel, drive.Name, drive.TotalSize, drive.TotalFreeSpace);
    else
        Console.WriteLine("类型：{0}  is not ready", drive.DriveType);
}
```

## 其他用法

上面是获取硬盘的信息。

```csharp
Console.WriteLine(Path.GetDirectoryName(LogPath));  //返回目录名，需要注意路径末尾是否有反斜杠对结果是有影响的
Console.WriteLine(Path.GetDirectoryName(@"d:\\abc")); //将返回 d:\
Console.WriteLine(Path.GetDirectoryName(@"d:\\abc\"));// 将返回 d:\abc
Console.WriteLine(Path.GetRandomFileName());//将返回随机的文件名
Console.WriteLine(Path.GetFileNameWithoutExtension("d:\\abc.txt"));// 将返回abc
Console.WriteLine(Path.GetInvalidPathChars());// 将返回禁止在路径中使用的字符
Console.WriteLine(Path.GetInvalidFileNameChars());//将返回禁止在文件名中使用的字符
Console.WriteLine(Path.Combine(LogPath, "log.txt"));//合并两个路径
```

获取文件的路径的各种方法。

```csharp
public static void Log(string msg)
{
    StreamWriter sw = null;
    try
    {
        string fileName = "log.txt";
        string totalPath = Path.Combine(LogPath, fileName);

        if (!Directory.Exists(LogPath))
        {
            Directory.CreateDirectory(LogPath);
        }
        sw = File.AppendText(totalPath);
        sw.WriteLine(string.Format("{0}:{1}", DateTime.Now, msg));
        sw.WriteLine("***************************************************");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);//log
        //throw ex;
        //throw new exception("这里异常");
    }
    finally
    {
        if (sw != null)
        {
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
    }
}
```

上面就是IO的一种应用，就是日志记录，在项目中日志是很重要的，用户在任何操作都可以进行日志的记录。

# IO的应用

```csharp
public static List<DirectoryInfo> GetAllDirectory(string rootPath)
{
    if (!Directory.Exists(rootPath))
        return new List<DirectoryInfo>();

    List<DirectoryInfo> directoryList = new List<DirectoryInfo>();//容器
    DirectoryInfo directory = new DirectoryInfo(rootPath);//root文件夹
    directoryList.Add(directory);

    return GetChild(directoryList, directory);
}
```

这是一种IO的应用，利用递归获取某个文件夹下所有的文件。

# 序列化和反序列化

序列化就是将数据通过某种规则转换成字符串，反序列化就是字符串通过某种规则转换成数据。

序列不只json格式，还有二进制，soap，xml等格式。下面.net 8版本的三种的实现代码。

```csharp
public static void BinarySerialize()
{
    //使用二进制序列化对象
    string fileName = Path.Combine(Constant.SerializeDataPath, @"BinarySerialize.txt");//文件名称与路径
    using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
    {//需要一个stream，这里是直接写入文件了
        List<Programmer> pList = DataFactory.BuildProgrammerList();
        BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
        binFormat.Serialize(fStream, pList);
    }
    using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
    {//需要一个stream，这里是来源于文件
        BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
        //使用二进制反序列化对象
        fStream.Position = 0;//重置流位置
        List<Programmer> pList = (List<Programmer>)binFormat.Deserialize(fStream);//反序列化对象
    }
}


/// <summary>
/// soap序列化器
/// </summary>
public static void SoapSerialize()
{
    //使用Soap序列化对象
    string fileName = Path.Combine(Constant.SerializeDataPath, @"SoapSerialize.txt");//文件名称与路径
    using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
    {
        List<Programmer> pList = DataFactory.BuildProgrammerList();
        SoapFormatter soapFormat = new SoapFormatter();//创建二进制序列化器
        //soapFormat.Serialize(fStream, list);//SOAP不能序列化泛型对象
        soapFormat.Serialize(fStream, pList.ToArray());
    }
    using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
    {
        SoapFormatter soapFormat = new SoapFormatter();//创建二进制序列化器
        //使用二进制反序列化对象
        fStream.Position = 0;//重置流位置
        List<Programmer> pList = ((Programmer[])soapFormat.Deserialize(fStream)).ToList();//反序列化对象
    }
}

/// <summary>
/// XML序列化器
/// </summary>
public static void XmlSerialize()
{
    //使用XML序列化对象
    string fileName = Path.Combine(Constant.SerializeDataPath, @"Student.xml");//文件名称与路径
    using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
    {
        List<Programmer> pList = DataFactory.BuildProgrammerList();
        XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));//创建XML序列化器，需要指定对象的类型
        xmlFormat.Serialize(fStream, pList);
    }
    using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
    {
        XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));//创建XML序列化器，需要指定对象的类型
        //使用XML反序列化对象
        fStream.Position = 0;//重置流位置
        List<Programmer> pList = pList = (List<Programmer>)xmlFormat.Deserialize(fStream);
    }
}
```

下面是直接转换成json的代码

```csharp
    public static string ObjectToString<T>(T obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
```