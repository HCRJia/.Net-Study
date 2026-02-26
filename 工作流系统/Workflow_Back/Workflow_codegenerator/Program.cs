using Workflow_codegenerator.generators;

#region 1、Scriban基本使用


{
    /*// 生成DemoTemplate.cs
    // 1、加载模板文件
    var DemoTemplateContent = File.ReadAllText("Templates/DemoTemplate.sbn");
    // 2、模板内容解析
    Template template = Template.Parse(DemoTemplateContent);
    // 3、模板内容渲染【核心】
    var result = template.Render(new
    {
        name = "User",
        filed1 = "Id",
        filed2 = "UserName",
        filed3 = "PassWord"
    });

    // 4、生成DemoTemplate.cs
    File.WriteAllText("DemoTemplate.cs", result);*/
}
#endregion

#region 2、Scriban深入使用-模板对象[模板变量取值都必须为小写]
{
    /*// 生成DemoTemplate.cs
    // 1、加载模板文件
    var DemoTemplateContent = File.ReadAllText("Templates/DemoTemplate.sbn");
    // 2、模板内容解析
    Template template = Template.Parse(DemoTemplateContent);
    // 3、模板内容渲染【核心】
    // 3.1、创建模板对象变量
    TemplateObject _templateObject = new TemplateObject();
    _templateObject.user = "User";
    _templateObject.username = "UserName";
    _templateObject.password = "Password";

    var result = template.Render(new
    {
        tony = _templateObject
    });

    // 4、生成DemoTemplate.cs
    File.WriteAllText("DemoTemplate.cs", result);*/
}
#endregion

#region 3、Scriban深入使用-模板集合对象
{
    /*// 生成DemoTemplate.cs
    // 1、加载模板文件
    var DemoTemplateContent = File.ReadAllText("Templates/DemoTemplateList.sbn");
    // 2、模板内容解析
    Template template = Template.Parse(DemoTemplateContent);
    // 3、模板内容渲染【核心】
    // 3.1、创建模板集合对象变量
    List<TemplateObject> _templateObjects =new List<TemplateObject>();
    _templateObjects.Add(new TemplateObject
    {
        user = "User1",
        username = "UserName1",
        password = "Password1",
    });
    _templateObjects.Add(new TemplateObject
    {
        user = "User2",
        username = "UserName2",
        password = "Password2",
    });

    var result = template.Render(new
    {
        filed1 = "Id",
        templateobjects = _templateObjects,
    });

    // 4、生成DemoTemplate.cs
    File.WriteAllText("DemoTemplate.cs", result);*/
}
#endregion

#region 4、Scriban深入使用-模板变量判断if
{
    /*// 生成DemoTemplate.cs
    // 1、加载模板文件
    var DemoTemplateContent = File.ReadAllText("Templates/DemoTemplateIf.sbn");
    // 2、模板内容解析
    Template template = Template.Parse(DemoTemplateContent);
    // 3、模板内容渲染【核心】
    // 3.1、创建模板集合对象变量
    List<TemplateObject> _templateObjects = new List<TemplateObject>();
    _templateObjects.Add(new TemplateObject
    {
        user = "User1",
        username = "UserName1",
        password = "Password1",
    });
    _templateObjects.Add(new TemplateObject
    {
        user = "User2",
        username = "UserName2",
        password = "Password2",
    });

    var result = template.Render(new
    {
        filed1 = "Id",
        templateobjects = _templateObjects,
    });

    // 4、生成DemoTemplate.cs
    File.WriteAllText("DemoTemplate.cs", result);*/
}
#endregion

#region 5、Scriban深入使用-代码换行
{
    /*// 生成DemoTemplate.cs
    // 1、加载模板文件
    var DemoTemplateContent = File.ReadAllText("Templates/DemoTemplateIfn.sbn");
    // 2、模板内容解析
    Template template = Template.Parse(DemoTemplateContent);
    // 3、模板内容渲染【核心】
    // 3.1、创建模板集合对象变量
    List<TemplateObject> _templateObjects = new List<TemplateObject>();
    _templateObjects.Add(new TemplateObject
    {
        user = "User1",
        username = "UserName1",
        password = "Password1",
    });
    _templateObjects.Add(new TemplateObject
    {
        user = "User2",
        username = "UserName2",
        password = "Password2",
    });

    var result = template.Render(new
    {
        filed1 = "Id",
        templateobjects = _templateObjects,
    });

    // 4、生成DemoTemplate.cs
    File.WriteAllText("DemoTemplate.cs", result);*/
}
#endregion

#region 6、Scriban深入使用-生成的代码放到指定的目录
{
    /*// 生成DemoTemplate.cs
    // 1、加载模板文件
    var DemoTemplateContent = File.ReadAllText("Templates/DemoTemplateIfn.sbn");
    // 2、模板内容解析
    Template template = Template.Parse(DemoTemplateContent);
    // 3、模板内容渲染【核心】
    // 3.1、创建模板集合对象变量
    List<TemplateObject> _templateObjects = new List<TemplateObject>();
    _templateObjects.Add(new TemplateObject
    {
        user = "User1",
        username = "UserName1",
        password = "Password1",
    });
    _templateObjects.Add(new TemplateObject
    {
        user = "User2",
        username = "UserName2",
        password = "Password2",
    });

    var result = template.Render(new
    {
        filed1 = "Id",
        templateobjects = _templateObjects,
    });

    // 4、生成DemoTemplate.cs
    // 4.1、创建指定的code目录
    // 确保code目录存在
    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

    // 获取项目的根目录
    DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
    for (int i = 0; i < 3; i++) // 根据实际目录层级调整循环次数
    {
        directoryInfo = directoryInfo.Parent;
    }

    string projectDirectory = directoryInfo.FullName;

    // 指定生成文件的目录
    string codeDirectory = Path.Combine(projectDirectory, "code");
    if (!Directory.Exists(codeDirectory))
    {
        Directory.CreateDirectory(codeDirectory);
    }

    // 生成文件的完整路径
    var outputPath = Path.Combine(codeDirectory, "DemoTemplate.cs");

    File.WriteAllText(outputPath, result);*/
}
#endregion

#region 7、代码生成器使用
{
    Console.WriteLine("代码生成中......");
    CodeGenerator codeGenerator = new CodeGenerator();
    codeGenerator.Generator();
    Console.WriteLine("代码生成完成......");
}
#endregion