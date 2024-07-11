using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class PrintDateClass : IExecutable
    {
        public static void PrintDate()
        {
            DateTime today = DateTime.Today;

            Console.WriteLine("The date today is: {0}", today.ToShortDateString());
        }

        public void Execute() => PrintDate();
    }
}