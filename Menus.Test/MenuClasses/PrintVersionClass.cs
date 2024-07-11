using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class PrintVersionClass : IExecutable
    {
        public static void PrintVersion()
        {
            Console.WriteLine("Version: 24.2.4.9504");
        }

        public void Execute() => PrintVersion();
    }
}