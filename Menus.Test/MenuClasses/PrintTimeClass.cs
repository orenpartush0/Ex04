using System;
﻿using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class PrintTimeClass : IExecutable
    {
        public static void PrintTime()
        {
            DateTime today = DateTime.Now;

            Console.WriteLine("The hour is: {0}", today.ToShortTimeString());
        }

        public void Execute() => PrintTime();
    }
}
