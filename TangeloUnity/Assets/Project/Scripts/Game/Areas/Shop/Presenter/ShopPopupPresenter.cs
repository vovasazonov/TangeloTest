using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.Presenter;
using Project.Scripts.Game.Areas.Popups.View;
using Project.Scripts.Game.Areas.Shop.View;

namespace Project.Scripts.Game.Areas.Shop.Presenter
{
    public class ShopPopupPresenter : PopupPresenter
    {
        private readonly IShopPopupView _shopView;

        public ShopPopupPresenter(IPopupModel model, IPopupView view, IShopPopupView shopView) : base(model, view)
        {
            _shopView = shopView;
        }

        protected override void LoadView()
        {
        }

        protected override void UnloadView()
        {
        }
    }
}