namespace Project.Scripts.Game.Areas.Popups
{
    public interface IPopupsFacade
    {
        void Open(string id);
        void Close(string id);
        void CloseAll();
    }
}