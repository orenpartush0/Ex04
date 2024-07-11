using System;
using System.Threading;

namespace Ex04.Menus.Delegates
{
    public class LeafItem : IMenuItem
    {
        public event Action ItemClicked;
        public string Title { get; }
        public bool ReUseAfterSelection { get; } = true;

        public LeafItem(string i_Title) => Title = i_Title;
        private void OnClick() 
        {
            ItemClicked?.Invoke();
            Thread.Sleep(2000);
        }
        public void HandleSelection() => OnClick(); 
    }
}