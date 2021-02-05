using System;
using System.Runtime.InteropServices;

namespace CoreConsoleLib
{
    public class MyClass
    {
        public static string MyFunc()
        {
            return
                $"当前系统平台:{RuntimeInformation.OSDescription}\n当前系统架构:{RuntimeInformation.OSArchitecture}\n当前日期时间:{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        }
    }
}