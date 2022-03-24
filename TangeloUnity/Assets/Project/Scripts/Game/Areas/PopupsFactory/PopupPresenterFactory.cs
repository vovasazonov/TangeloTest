using System;
using Project.Scripts.Core.Logger;
using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Areas.Browser.Model;
using Project.Scripts.Game.Areas.ClassicPopup.Presenter;
using Project.Scripts.Game.Areas.ClassicPopup.View;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.Presenter;
using Project.Scripts.Game.Areas.Popups.View;
using Project.Scripts.Game.Areas.Shop.Presenter;
using Project.Scripts.Game.Areas.Shop.View;

namespace Project.Scripts.Game.Areas.PopupsFactory
{
    public class PopupPresenterFactory : IPopupPresenterFactory
    {
        private readonly IPopupsModel _popupsModel;
        private readonly IBrowserModel _browserModel;
        private readonly ILogger _logger;

        public PopupPresenterFactory(IPopupsModel popupsModel, IBrowserModel browserModel, ILogger logger)
        {
            _popupsModel = popupsModel;
            _browserModel = browserModel;
            _logger = logger;
        }

        public IPresenter Create(IPopupView view)
        {
            _popupsModel.Initialize(view.Id);

            PopupPresenter presenter;
            IPopupModel model = _popupsModel.Popups[view.Id];

            switch (view)
            {
                case ClassicPopupView _:
                    presenter = new ClassicPopupPresenter(model, view, _browserModel, _logger);
                    break;
                case ShopPopupView shopPopupView:
                    presenter = new ShopPopupPresenter(model, view, shopPopupView, _browserModel, _logger);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(view));
            }

            return presenter;
        }
    }
}