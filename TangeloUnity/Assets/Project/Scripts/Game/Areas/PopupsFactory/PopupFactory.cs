using System;
using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Areas.ClassicPopup.Presenter;
using Project.Scripts.Game.Areas.ClassicPopup.View;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.PopupPresenter;
using Project.Scripts.Game.Areas.Popups.View;
using Project.Scripts.Game.Areas.Shop.Presenter;
using Project.Scripts.Game.Areas.Shop.View;

namespace Project.Scripts.Game.Areas.PopupsFactory
{
    public class PopupPresenterFactory : IPopupPresenterFactory
    {
        private readonly IPopupsModel _popupsModel;

        public PopupPresenterFactory(IPopupsModel popupsModel)
        {
            _popupsModel = popupsModel;
        }

        public IPresenter Create(IPopupView view)
        {
            _popupsModel.Initialize(view.Id);

            PopupPresenter presenter;
            IPopupModel model = _popupsModel.Popups[view.Id];

            switch (view)
            {
                case ClassicPopupView _:
                    presenter = new ClassicPopupPresenter(model, view);
                    break;
                case ShopPopupView shopPopupView:
                    presenter = new ShopPopupPresenter(model, view, shopPopupView);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(view));
            }

            return presenter;
        }
    }
}