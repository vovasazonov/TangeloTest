using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Areas.Popups.View;

namespace Project.Scripts.Game.Areas.Popups.Presenter
{
    public interface IPopupPresenterFactory
    {
        IPresenter Create(IPopupView view);
    }
}