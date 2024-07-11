using System;
using System.Threading;

namespace Ex04.Menus.Delegates
{
    public class LeafItem : IMenuItem
    {
        public string Title { get; }
        public event Action ItemClicked;

        public LeafItem(string i_Title) => Title = i_Title;
        private bool OnClick() 
        {
            ItemClicked?.Invoke();
            Thread.Sleep(2000);

            return true;
        }
        public bool HandleSelection() => OnClick(); 
    }
}