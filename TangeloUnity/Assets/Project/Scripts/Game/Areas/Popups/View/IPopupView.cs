using System;

namespace Project.Scripts.Game.Areas.Popups.View
{
    public interface IPopupView : IDisposable
    {
        event Action CloseClicked;
        
        string Id { get; }
        
        void SetOrder(int order);
        void Open();
        void Close();
    }
}