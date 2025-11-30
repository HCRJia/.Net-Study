using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; //nuget Newtonsoft

namespace IOSerialize.Serialize
{
    public class JsonHelper
    {
        #region Json
        /// <summary>
        /// 将对象序列化为 JSON 字符串（替代 JavaScriptSerializer）
        /// </summary>
        public static string ObjectToString<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 将 JSON 字符串反序列化为对象（替代 JavaScriptSerializer）
        /// </summary>
        public static T StringToObject<T>(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return default!;
            return JsonConvert.DeserializeObject<T>(content)!;
        }

        /// <summary>
        /// JsonConvert.SerializeObject
        /// </summary>
        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// JsonConvert.DeserializeObject
        /// </summary>
        public static T ToObject<T>(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return default!;
            return JsonConvert.DeserializeObject<T>(content)!;
        }
        #endregion Json
    }
}