using MySql.Data.MySqlClient;
using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_codegenerator.Templates;

namespace Workflow_codegenerator.generators
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public class CodeGenerator
    {
        /// <summary>
        /// 生成业务代码
        /// </summary>
        public void Generator()
        {
            // 1.1、创建MySQL连接地址
            var connectionString = "Server=localhost;Database=workflows;User=root;Password=259259;";

            // 1.2、获取模型变量集合
            List<Entity> entities = GetAllTables(connectionString);

            // 1.3、生成业务代码【业务模型】
            foreach (Entity entity in entities)
            {
                //1.4、生成Model
                GeneratorEbuisness("generators/ModelTemplate.sbn", $"{entity.name}.cs", entity, "Models");
                //1.5、生成仓储接口
                GeneratorEbuisness("generators/IRepositoryTemplate.sbn", $"I{entity.name}Repository.cs", entity, "IRepositorys");
                //1.5、生成仓储实现
                GeneratorEbuisness("generators/RepositoryTemplate.sbn", $"{entity.name}Repository.cs", entity, "Repositorys");
                //1.5、生成Service接口
                GeneratorEbuisness("generators/IServiceTemplate.sbn", $"I{entity.name}Service.cs", entity, "IServices");
                //1.6、生成Service实现
                GeneratorEbuisness("generators/ServiceTemplate.sbn", $"{entity.name}Service.cs", entity, "Services");
                //1.7、生成Controllers
                GeneratorEbuisness("generators/ControllerTemplate.sbn", $"{entity.name}Controller.cs", entity, "Controllers");
            }

            // 1.4、生成Contexts代码
            GeneratorContexts("generators/IContextTemplate.sbn", $"IWorkflowDbContext.cs", entities, "Contexts");
            // 1.5、生成Contexts代码
            GeneratorContexts("generators/ContextTemplate.sbn", $"WorkflowDbContext.cs", entities, "Contexts");

            // 1.6、生成Program代码
            GeneratorProgram("generators/ProgramTemplate.sbn", $"Program.cs", entities);
        }
        /// <summary>
        /// 11、生成Contexts代码
        /// </summary>
        /// <param name="TemplatePath"></param>
        /// <param name="ModelFileName"></param>
        /// <param name="entity"></param>

        private static void GeneratorProgram(string TemplatePath, string ModelFileName, List<Entity> entities)
        {
            // 1、加载模板文件"generators/ModelTemplate.sbn"
            var DemoTemplateContent = File.ReadAllText(TemplatePath);
            // 2、模板内容解析
            Template template = Template.Parse(DemoTemplateContent);
            // 3、模板渲染
            var result = template.Render(new
            {
                entities = entities,  // 模型集合
            });

            //4、生成对应的模型文件
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

            // 生成文件的完整路径$"{entity.name}.cs"
            var outputPath = Path.Combine(codeDirectory, ModelFileName);

            File.WriteAllText(outputPath, result);
        }

        /// <summary>
        /// 11、生成Contexts代码
        /// </summary>
        /// <param name="TemplatePath"></param>
        /// <param name="ModelFileName"></param>
        /// <param name="entity"></param>

        private static void GeneratorContexts(string TemplatePath, string ModelFileName, List<Entity> entities, string Classfly)
        {
            // 1、加载模板文件"generators/ModelTemplate.sbn"
            var DemoTemplateContent = File.ReadAllText(TemplatePath);
            // 2、模板内容解析
            Template template = Template.Parse(DemoTemplateContent);
            // 3、模板渲染
            var result = template.Render(new
            {
                entities = entities,  // 模型集合
            });

            //4、生成对应的模型文件
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
            string codeDirectory = Path.Combine(projectDirectory, "code", Classfly);
            if (!Directory.Exists(codeDirectory))
            {
                Directory.CreateDirectory(codeDirectory);
            }

            // 生成文件的完整路径$"{entity.name}.cs"
            var outputPath = Path.Combine(codeDirectory, ModelFileName);

            File.WriteAllText(outputPath, result);
        }

        /// <summary>
        /// 10、生成业务代码
        /// </summary>
        /// <param name="TemplatePath"></param>
        /// <param name="ModelFileName"></param>
        /// <param name="entity"></param>

        private static void GeneratorEbuisness(string TemplatePath,string ModelFileName,Entity entity,string Classfly)
        {
            // 1、加载模板文件"generators/ModelTemplate.sbn"
            var DemoTemplateContent = File.ReadAllText(TemplatePath);
            // 2、模板内容解析
            Template template = Template.Parse(DemoTemplateContent);
            // 3、模板渲染
            var result = template.Render(new
            {
                name = entity.name,  // 模型名
                comment = entity.comment,// 表注释
                tablename = entity.tablename,// 表名
                propertities = entity.propertities, // 字段集合
            });

            //4、生成对应的模型文件
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
            string codeDirectory = Path.Combine(projectDirectory, "code", Classfly);
            if (!Directory.Exists(codeDirectory))
            {
                Directory.CreateDirectory(codeDirectory);
            }

            // 生成文件的完整路径$"{entity.name}.cs"
            var outputPath = Path.Combine(codeDirectory, ModelFileName);

            File.WriteAllText(outputPath, result);
        }


        /// <summary>
        /// 1、获取ydt_workflows所有表 [MySql.Data]
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static List<Entity> GetAllTables(string connectionString)
        {
            List<Entity> entities = new List<Entity>();
            // 1.2、创建MySQL连接
            using (var connection = new MySqlConnection(connectionString))
            {
                // 1.3、打开连接
                connection.Open();
                // 1.4、获取所有表命令
                var tableCommand = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'workflows'",
                            connection);
                //1.5、读取所有表
                using (var reader = tableCommand.ExecuteReader())
                {
                    //1.6、遍历所有的表
                    while (reader.Read())
                    {
                        //1.7、读取表名称ydt_role....
                        var tableName = reader.GetString(0);

                        // 1.8、转换成模型变量Entity
                        Entity entity = new Entity();
                        entity.tablename = tableName; // 1、赋值表名
                        entity.comment = GetTabllComments(connectionString, tableName); //2、赋值表注释
                        entity.name = TableNameToModelName(tableName); // 3、赋值模型名
                        entity.propertities = GetTableTileds(connectionString, tableName);// 4、赋值字段集合: ydt_user

                        // 1.10、赋值给List<Entity>
                        entities.Add(entity);
                    }
                }
            }

            //1.11、返回List<Entity>
            return entities;
        }


        //8、表名转换【表名转换成模型名】例如：ydt_user--->User
        public static string TableNameToModelName(string tableName)
        {
            // 去掉前缀 "ydt_"
            if (tableName.StartsWith("ydt_"))
            {
                tableName = tableName.Substring(4);
            }

            // 将下划线分隔的表名转换为驼峰命名法
            var parts = tableName.Split('_');
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1);
            }

            return string.Join(string.Empty, parts);
        }


        /// <summary>
        /// 2、获取所有表字段
        /// </summary>
        private static List<Propertity> GetTableTileds(string connectionString, string tableName)
        {
            // 2.9、创建模型集合变量Propertity
            List<Propertity> propertities = new List<Propertity>();
            
            //2.1、创建MySQL连接
            using (var connection = new MySqlConnection(connectionString))
            {
                // 2.2、打开连接
                connection.Open();

                //2.3、创建获取表所有字段的命令
                var columnCommand = new MySqlCommand($"SELECT COLUMN_NAME, DATA_TYPE, COLUMN_COMMENT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName AND TABLE_SCHEMA = 'workflows'",
                                    connection);
                columnCommand.Parameters.AddWithValue("@TableName", tableName);

                // 2.4、读取所有的字段
                using (var columnReader = columnCommand.ExecuteReader())
                {
                    //2.5、遍历所有的字段
                    while (columnReader.Read())
                    {

                        //2.6、读取每一个字段[字段名和字段类型]
                        string name = columnReader.GetString(0); // Id
                        string type = columnReader.GetString(1); // int VARCHAR
                                                                 // string comment = columnReader["COLUMN_COMMENT"].ToString();
                        string comment = columnReader.GetString(2); // 注释
                        //2.7、转换成模型集合变量Propertity
                        Propertity propertity = new Propertity();
                        propertity.name = name;// 1、赋值字段名
                        propertity.type = MySQLTypeToCSharpType(type); // 2、赋值字段类型【数据库字段类型转换】
                        propertity.comment = comment;

                        // 2.9、赋值到List<Propertity>
                        propertities.Add(propertity);
                    }
                }
            }

            //2.10、返回List<Propertity>
            return propertities;
        }

        /// <summary>
        /// 3、获取所有表注释
        /// </summary>
        private static string GetTabllComments(string connectionString, string tableName)
        {
            //3.1、创建MySQL连接
            using (var connection = new MySqlConnection(connectionString))
            {
                // 3.2、打开连接
                connection.Open();

                // 3.3、创建表注释脚本
                var command = new MySqlCommand(@"
        SELECT 
            table_comment 
        FROM 
            information_schema.tables 
        WHERE 
            table_schema = 'ydt_workflows' 
            AND table_name = @TableName", connection);
                command.Parameters.AddWithValue("@TableName", tableName);

                //3.4、回去所有表注释
               return command.ExecuteScalar()?.ToString();
            }
        }

        /// <summary>
        /// 4、字段类型转换
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        private static string MySQLTypeToCSharpType(string dbType) 
        {
            switch (dbType.ToLower())
            {
                case "int":
                case "integer":
                case "smallint":
                case "mediumint":
                case "int2":
                case "int4":
                    return "int";
                case "bigint":
                case "int8":
                    return "long";
                case "float":
                case "real":
                    return "float";
                case "double":
                case "double precision":
                    return "double";
                case "decimal":
                case "numeric":
                    return "decimal";
                case "bit":
                case "bool":
                case "boolean":
                    return "bool";
                case "char":
                case "varchar":
                case "text":
                case "tinytext":
                case "mediumtext":
                case "longtext":
                    return "string";
                case "date":
                case "datetime":
                case "timestamp":
                    return "DateTime";
                case "time":
                    return "TimeSpan";
                case "blob":
                case "binary":
                case "varbinary":
                case "tinyblob":
                case "mediumblob":
                case "longblob":
                    return "byte[]";
                default:
                    return "object"; // 默认类型
            }
        }
    }
}
