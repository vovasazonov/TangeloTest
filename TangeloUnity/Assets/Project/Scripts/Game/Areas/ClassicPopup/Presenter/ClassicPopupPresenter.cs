using Project.Scripts.Core.Logger;
using Project.Scripts.Game.Areas.Browser.Model;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.Presenter;
using Project.Scripts.Game.Areas.Popups.View;

namespace Project.Scripts.Game.Areas.ClassicPopup.Presenter
{
    public class ClassicPopupPresenter : PopupPresenter
    {
        public ClassicPopupPresenter(IPopupModel model, IPopupView view, IBrowserModel browser, ILogger logger) : base(model, view, browser, logger)
        {
        }
    }
}