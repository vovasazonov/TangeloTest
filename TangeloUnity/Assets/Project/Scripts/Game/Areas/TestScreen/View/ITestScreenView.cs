using System;

namespace Project.Scripts.Game.Areas.TestMenu.View
{
    public interface ITestScreenView : IDisposable
    {
        event Action<string> OpenPopupClicked;
        event Action OpenAllPopupsClicked;
    }
}