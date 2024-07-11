using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
    {
        private const int k_MinChoice = 0;
        public string Title { get; }
        private List<IMenuItem> MenuItems { get; } = new List<IMenuItem>();
        public bool ReUseAfterSelection { get; } = false;
        public MenuItem(string i_ItemTitle) => Title = i_ItemTitle;
        public void HandleSelection() => showMenu();

        private void showMenu()
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
        }

        private void menuExecute()
        {
            int menuChoice = getMenuChoiceInRange();

            MenuItems[menuChoice]?.HandleSelection();
            if (MenuItems[menuChoice] != null && MenuItems[menuChoice].ReUseAfterSelection)
            {
                showMenu();
            }
        }

        private void printBackOrExitInInstructionsByType() => Console.WriteLine($"Enter your request: (1 to {MenuItems.Count - 1} or press '0' to {getBackOrExitMessage()})");
        private string getBackOrExitMessage() => MenuItems[0] == null ? "Exit" : "Back";
        private void showOptionOfBackOrExit() => Console.WriteLine($"0 --> {getBackOrExitMessage()}");
        public void AddItemToMenu(IMenuItem i_MenuItem) => MenuItems.Add(i_MenuItem);

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