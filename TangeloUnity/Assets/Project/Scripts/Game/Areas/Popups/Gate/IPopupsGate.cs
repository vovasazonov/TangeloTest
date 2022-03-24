namespace Project.Scripts.Game.Areas.Popups.Gate
{
    public interface IPopupsGate
    {
        void Open(string id);
        void OpenLoaded(string id);
        void Close(string id);
        void CloseUnloaded(string id);
        void CloseAll();
        void OpenAll();
    }
}