using IDAL;
using Microsoft.Data.SqlClient;
using Model;
using System.Configuration;

namespace DAL
{
    public class BaseDAL:IBaseDAL
    {
        public T FindT<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            string sql = $"SELECT {string.Join(",",type.GetProperties().Select(p=>$"[{p.Name}]"))} FROM [{type.Name}] WHERE Id=@Id";
            object oBject = Activator.CreateInstance(type);
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(oBject, reader[prop.Name]);
                    }
                }
                else
                {
                    oBject = null;
                }
            }
            return (T)oBject;
        }

        public List<T> FindAllT<T>() where T : BaseModel
        {
            Type type = typeof(T);
            string sql = $"SELECT {string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"))} FROM [{type.Name}]" ;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<T> list = new List<T>();
                while (reader.Read())
                {
                    object oBject = Activator.CreateInstance(type);
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(oBject, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                    }
                    list.Add((T)oBject);
                }
                return list;
            }
        }

        public bool InsertT<T>(T model) where T : BaseModel
        {
            Type type = typeof(T);
            var properties = type.GetProperties().Where(p => p.Name != "Id").ToList();
            string columns = string.Join(",", properties.Select(p => $"[{p.Name}]"));
            string parameters = string.Join(",", properties.Select(p => $"@{p.Name}"));
            string sql = $"INSERT INTO [{type.Name}] ({columns}) VALUES ({parameters})";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                foreach (var prop in properties)
                {
                    command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(model) ?? DBNull.Value);
                }
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }

        }

        public bool UpdateT<T>(T model) where T : BaseModel
        {
            Type type = typeof(T);
            var properties = type.GetProperties().Where(p => p.Name != "Id").ToList();
            string setClause = string.Join(",", properties.Select(p => $"[{p.Name}]=@{p.Name}"));
            string parameters = string.Join(",", properties.Select(p => $"@{p.Name}"));
            string sql = $"UPDATE [{type.Name}] SET {setClause} WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                foreach (var prop in properties)
                {
                    command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(model) ?? DBNull.Value);
                }
                command.Parameters.AddWithValue("@Id", type.GetProperty("Id").GetValue(model));
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }

        }

        public bool DeleteT<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            string sql = $"DELETE FROM [{type.Name}] WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
