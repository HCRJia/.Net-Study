using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

namespace IOSerialize.Serialize
{
    public class SerializeHelper
    {
        /// <summary>
        /// 二进制（使用 UTF-8 JSON bytes 作为示例的二进制保存，兼容 .NET 8）
        /// </summary>
        public static void BinarySerialize()
        {
            string fileName = Path.Combine(Constant.SerializeDataPath, "BinarySerialize.bin");
            // 序列化写入（写入为 UTF-8 JSON bytes）
            List<Programmer> pList = DataFactory.BuildProgrammerList();
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(pList, new JsonSerializerOptions { WriteIndented = false });
            Directory.CreateDirectory(Path.GetDirectoryName(fileName) ?? string.Empty);
            using (FileStream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fStream.Write(bytes, 0, bytes.Length);
            }

            // 读取并反序列化
            using (FileStream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                byte[] readBytes = new byte[fStream.Length];
                int read = fStream.Read(readBytes, 0, readBytes.Length);
                List<Programmer> pListDeser = JsonSerializer.Deserialize<List<Programmer>>(readBytes);
            }
        }

        /// <summary>
        /// 用 XmlSerializer 序列化成 XML（替代旧的 SoapFormatter 实现，兼容 .NET 8）
        /// </summary>
        public static void SoapSerialize()
        {
            // 使用 XmlSerializer 序列化数组（SOAP formatter 在 .NET Core/.NET 5+ 不可用）
            string fileName = Path.Combine(Constant.SerializeDataPath, "SoapSerialize.xml");
            List<Programmer> pList = DataFactory.BuildProgrammerList();
            Directory.CreateDirectory(Path.GetDirectoryName(fileName) ?? string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Programmer[]));
            using (FileStream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fStream, pList.ToArray());
            }

            using (FileStream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                fStream.Position = 0;
                List<Programmer> pListDeser = ((Programmer[])xmlSerializer.Deserialize(fStream)).ToList();
            }
        }

        /// <summary>
        /// XML序列化器
        /// </summary>
        public static void XmlSerialize()
        {
            string fileName = Path.Combine(Constant.SerializeDataPath, "Student.xml");
            Directory.CreateDirectory(Path.GetDirectoryName(fileName) ?? string.Empty);

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                List<Programmer> pList = DataFactory.BuildProgrammerList();
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));
                xmlFormat.Serialize(fStream, pList);
            }
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));
                fStream.Position = 0;
                List<Programmer> pList = (List<Programmer>)xmlFormat.Deserialize(fStream);
            }
        }

        /// <summary>
        /// json也可以的
        /// </summary>
        public static void Json()
        {
            List<Programmer> pList = DataFactory.BuildProgrammerList();
            string result = JsonHelper.ObjectToString<List<Programmer>>(pList);
            List<Programmer> pList1 = JsonHelper.StringToObject<List<Programmer>>(result);
        }
    }
}