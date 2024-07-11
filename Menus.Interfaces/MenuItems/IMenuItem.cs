namespace Ex04.Menus.Interfaces
{
    public interface IMenuItem
    {
        string Title { get; }
        bool HandleSelection();
    }
}