using System;
using CoreConsoleLib;

namespace CoreConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello .Net Core!");
            Console.WriteLine(MyClass.MyFunc());

            Console.WriteLine("Press any key exit...");
            Console.ReadKey(true);
        }
    }
}