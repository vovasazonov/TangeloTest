using System;

namespace Project.Scripts.Game.Areas.TestScreen.View
{
    public interface ITestScreenView : IDisposable
    {
        event Action<string> OpenPopupClicked;
        event Action OpenAllPopupsClicked;
    }
}