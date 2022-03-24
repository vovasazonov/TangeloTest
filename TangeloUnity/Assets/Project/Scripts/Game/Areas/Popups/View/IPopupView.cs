using System;
using System.Collections.Generic;

namespace Project.Scripts.Game.Areas.Popups.View
{
    public interface IPopupView : IDisposable
    {
        event Action CloseClicked;
        event Action<string> UrlClicked;
        event Action Disappeared;
        
        string Id { get; }
        IEnumerable<UrlImage> UrlImages { get; }

        void SetOrder(int order);
        void Open();
        void Close();
        void CloseImmediately();
        void UnloadUrlImages();
    }
}