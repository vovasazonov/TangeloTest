namespace Project.Scripts.Game.Areas.Popups
{
    public interface IPopups
    {
        void Open(string id);
        void Close(string id);
        void CloseAll();
        void OpenAll();
    }
}