using System;

namespace Project.Scripts.Game.Areas.Browser.Model
{
    public interface IBrowserModel
    {
        void Browse(string url);
        void Download<T>(string url, Action<T> success, Action<string> error);
    }
}