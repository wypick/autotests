using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace TestRest
{
    public class Config
    {
        public static TimeSpan WebDriverWait { get; set; } = TimeSpan.FromSeconds(30);
        public static string BasePath = new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath).DirectoryName;
    }
}


