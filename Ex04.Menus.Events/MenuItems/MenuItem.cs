using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Delegates
{
    public class MenuItem : IMenuItem
    {
        private const int k_MinChoice = 0;
        private List<IMenuItem> MenuItems { get; } = new List<IMenuItem>();
        public string Title { get; }
        public MenuItem(string i_ItemTitle) => Title = i_ItemTitle;
        public int Count() => MenuItems.Count;

        private bool showMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"**{Title}**");
                Console.WriteLine("=====================");
                foreach (var (menu, index) in MenuItems.Skip(1).Select((item, i) => (item, i + 1)))
                {
                    Console.WriteLine($"{index} --> {menu.Title}");
                }

                showOptionOfBackOrExit();
                printBackOrExitInInstructionsByType();
                menuExecute();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                showMenu();
            }

            return false;
        }

        private void menuExecute()
        {
            int menuChoice = getMenuChoiceInRange();

            if (MenuItems[menuChoice] != null && MenuItems[menuChoice].HandleSelection())
            {
                showMenu();
            }
        }

        private void printBackOrExitInInstructionsByType() => Console.WriteLine($"Enter your request: (1 to {MenuItems.Count - 1} or press '0' to {getBackOrExitMessage()}");
        private string getBackOrExitMessage() => MenuItems[0] == null ? "Exit" : "Back";
        private void printBackOrExitByType() => Console.WriteLine($"0 --> {getBackOrExitMessage()}");
        private void showOptionOfBackOrExit() => Console.WriteLine($"0 --> {getBackOrExitMessage()}");
        public void AddItemToMenu(IMenuItem i_MenuItem) => MenuItems.Add(i_MenuItem);
        public bool HandleSelection() => showMenu();

        private int getMenuChoiceInRange()
        {
            string choice = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(choice, out int choiceInNum))
            {
                throw new FormatException("Invalid input!");
            }

            if (choiceInNum < k_MinChoice || choiceInNum >= MenuItems.Count)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }

            return choiceInNum;
        }
    }
}