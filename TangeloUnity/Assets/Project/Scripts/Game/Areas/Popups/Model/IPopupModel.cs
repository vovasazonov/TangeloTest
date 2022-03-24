using System;

namespace Project.Scripts.Game.Areas.Popups.Model
{
    public interface IPopupModel
    {
        event Action<IPopupModel> Opened;
        event Action<IPopupModel> Closed;
        event Action OrderChanged;
        event Action LoadStatusUpdated;
        event Action Loading;

        string Id { get; }
        int Order { get; set; }
        bool IsOpen { get; }
        bool IsLoaded { get; set; }

        void Open();
        void Close();
        void Load();
        void Unload();
        void OpenLoaded();
        void CloseUnloaded();
    }
}