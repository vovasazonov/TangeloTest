namespace Project.Scripts.Game.Areas.Popups
{
    public interface IPopups
    {
        void Open(string id);
        void OpenLoaded(string id);
        void Close(string id);
        void CloseUnloaded(string id);
        void CloseAll();
        void OpenAll();
        void QueueDisplay(string id);
    }
}