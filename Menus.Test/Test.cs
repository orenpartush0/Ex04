using System;


namespace Ex04.Menus.Test
{
    public class Test
    {
        public void StartDelegatesTest()
        {
            Delegates.MainMenu mainMenudDelegates = getDelegatesMainMenu();
            mainMenudDelegates.RunMenu();

            Console.Clear();

            Interfaces.MainMenu mainMenuInterface = getInterfacessMainMenu();
            mainMenuInterface.RunMenu();
        }

        private Delegates.MainMenu getDelegatesMainMenu()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu();
            Delegates.MenuItem dateAndTimeMenu = new Delegates.MenuItem("Show Date/Time");
            dateAndTimeMenu.AddItemToMenu(mainMenu.GetMainMenu());
            Delegates.LeafItem showDateItem = new Delegates.LeafItem("Show Date");
            showDateItem.ItemClicked += PrintDateClass.PrintDate;
            dateAndTimeMenu.AddItemToMenu(showDateItem);
            Delegates.LeafItem showTimeItem = new Delegates.LeafItem("Show Time");
            showTimeItem.ItemClicked += PrintTimeClass.PrintTime;
            dateAndTimeMenu.AddItemToMenu(showTimeItem);
            mainMenu.AddItemToMenu(dateAndTimeMenu);
            Delegates.MenuItem versionAndSpacesMenu = new Delegates.MenuItem("Version and Capitals");
            versionAndSpacesMenu.AddItemToMenu(mainMenu.GetMainMenu());
            Delegates.LeafItem showVersionItem = new Delegates.LeafItem("Show Version");
            showVersionItem.ItemClicked += PrintVersionClass.PrintVersion;
            versionAndSpacesMenu.AddItemToMenu(showVersionItem);
            Delegates.LeafItem countSpacesItem = new Delegates.LeafItem("Count Capitals");
            countSpacesItem.ItemClicked += CountCapitalsClass.CountCapitals;
            versionAndSpacesMenu.AddItemToMenu(countSpacesItem);
            mainMenu.AddItemToMenu(versionAndSpacesMenu);

            return mainMenu;
        }

        private Interfaces.MainMenu getInterfacessMainMenu()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu();
            Interfaces.MenuItem dateAndTimeMenu = new Interfaces.MenuItem("Show Date/Time");
            dateAndTimeMenu.AddItemToMenu(mainMenu.GetMainMenu());
            Interfaces.LeafItem showDateItem = new Interfaces.LeafItem("Show Date", new PrintDateClass());
            dateAndTimeMenu.AddItemToMenu(showDateItem);
            Interfaces.LeafItem showTimeItem = new Interfaces.LeafItem("Show Time", new PrintTimeClass());
            dateAndTimeMenu.AddItemToMenu(showTimeItem);
            mainMenu.AddItemToMenu(dateAndTimeMenu);
            Interfaces.MenuItem versionAndSpacesMenu = new Interfaces.MenuItem("Version and Capitals");
            versionAndSpacesMenu.AddItemToMenu(mainMenu.GetMainMenu());
            Interfaces.LeafItem showVersionItem = new Interfaces.LeafItem("Show Version", new PrintVersionClass());
            versionAndSpacesMenu.AddItemToMenu(showVersionItem);
            Interfaces.LeafItem countSpacesItem = new Interfaces.LeafItem("Count Capitals", new CountCapitalsClass());
            versionAndSpacesMenu.AddItemToMenu(countSpacesItem);
            mainMenu.AddItemToMenu(versionAndSpacesMenu);

            return mainMenu;
        }
    }
}