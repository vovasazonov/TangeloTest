using Project.Scripts.Core.Logger;
using Project.Scripts.Game.Areas.Browser.Model;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.Presenter;
using Project.Scripts.Game.Areas.Popups.View;
using Project.Scripts.Game.Areas.Shop.View;

namespace Project.Scripts.Game.Areas.Shop.Presenter
{
    public class ShopPopupPresenter : PopupPresenter
    {
        private readonly IShopPopupView _shopView;

        public ShopPopupPresenter(IPopupModel model, IPopupView view, IShopPopupView shopView, IBrowserModel browser, ILogger logger) : base(model, view, browser, logger)
        {
            _shopView = shopView;

            RenderView();
        }

        private void RenderView()
        {
            _shopView.AvailableCoins = 999999;
        }
    }
}