using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Service
{
    internal class FileText
    {
        public static StreamWriter CreateDeletingText(string fileName)
        {
            var root = Directory.GetCurrentDirectory();

            var filePath = Path.Combine(root + "/AppData", fileName);

            return File.CreateText(filePath);
        }
    }
}
