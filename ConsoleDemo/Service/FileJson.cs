using ConsoleDemo.Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Service
{
    internal class FileJson
    {
        internal static void CreateJson<T>(T data,string fileName) {
            var jsonData = JsonConvert.SerializeObject(data);

            var root = Directory.GetCurrentDirectory();

            var filePath = Path.Combine(root + "\\AppData", fileName);

            File.WriteAllText(filePath, jsonData, Encoding.UTF8);
        }
    }
}
