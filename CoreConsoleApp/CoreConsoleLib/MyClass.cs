using System;
using System.Runtime.InteropServices;

namespace CoreConsoleLib
{
    public class MyClass
    {
        public static void MyFunc()
        {
            Console.WriteLine($"当前系统平台:{RuntimeInformation.OSDescription}");
            Console.WriteLine($"当前系统架构:{RuntimeInformation.OSArchitecture}");
            Console.WriteLine($"当前日期时间:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
