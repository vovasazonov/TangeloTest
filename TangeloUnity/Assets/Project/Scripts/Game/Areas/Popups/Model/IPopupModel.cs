using System;

namespace Project.Scripts.Game.Areas.Popups.Model
{
    public interface IPopupModel
    {
        event Action<IPopupModel> Opened;
        event Action<IPopupModel> Closed;
        event Action OrderChanged;

        string Id { get; }
        int Order { get; set; }
        bool IsOpen { get; }

        void Open();
        void Close();
    }
}