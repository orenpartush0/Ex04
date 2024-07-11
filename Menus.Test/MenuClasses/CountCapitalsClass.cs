using System;
using System.Linq;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountCapitalsClass : IExecutable
    {
        public static void CountCapitals()
        {
            Console.WriteLine("Please enter a string:");
            string userInput = Console.ReadLine() ?? string.Empty;

            int numOfCaptials = userInput.Count(ch => !char.IsLower(ch));

            Console.WriteLine($"The number of capitals found in the string is {numOfCaptials}");
        }

        public void Execute() => CountCapitals();
    }
}