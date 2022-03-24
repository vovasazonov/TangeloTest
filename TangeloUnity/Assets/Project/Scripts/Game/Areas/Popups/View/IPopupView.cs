using System;
using System.Collections.Generic;

namespace Project.Scripts.Game.Areas.Popups.View
{
    public interface IPopupView : IDisposable
    {
        event Action CloseClicked;
        event Action<string> UrlClicked;
        
        string Id { get; }
        IEnumerable<UrlImage> UrlImages { get; }

        void SetOrder(int order);
        void Open();
        void Close();
    }
}