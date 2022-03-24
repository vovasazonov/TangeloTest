using System;
using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Areas.Browser;
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
        private readonly IBrowserModel m_BrowserModel;

        public PopupPresenterFactory(IPopupsModel popupsModel, IBrowserModel browserModel)
        {
            _popupsModel = popupsModel;
            m_BrowserModel = browserModel;
        }

        public IPresenter Create(IPopupView view)
        {
            _popupsModel.Initialize(view.Id);

            PopupPresenter presenter;
            IPopupModel model = _popupsModel.Popups[view.Id];

            switch (view)
            {
                case ClassicPopupView _:
                    presenter = new ClassicPopupPresenter(model, view, m_BrowserModel);
                    break;
                case ShopPopupView shopPopupView:
                    presenter = new ShopPopupPresenter(model, view, shopPopupView, m_BrowserModel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(view));
            }

            return presenter;
        }
    }
}