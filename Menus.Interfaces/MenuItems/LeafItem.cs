using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class LeafItem : IMenuItem
    {
        private IExecutable Executable { get; set; }
        public bool ReUseAfterSelection { get; } = true;

        public string Title { get; }

        public LeafItem(string i_Title, IExecutable i_Executable)
        {
            Title = i_Title;
            Executable = i_Executable;
        }

        public bool HandleSelection() 
        {
            Executable.Execute();
            Thread.Sleep(2000);

            return ReUseAfterSelection;
        }
    }
}