namespace Ex04.Menus.Delegates
{
    public interface IMenuItem
    {
        string Title { get; }
        bool ReUseAfterSelection { get; }
        void HandleSelection();
    }
}