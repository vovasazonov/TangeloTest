using System.Collections.Generic;
using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Areas.Popups.View;

namespace Project.Scripts.Game.Areas.Popups.Presenter
{
    public class PopupsPresenter : IPresenter
    {
        private readonly List<IPresenter> _presenters = new List<IPresenter>();

        public PopupsPresenter(IPopupPresenterFactory popupPresenterFactory, IPopupsView views)
        {
            foreach (var viewCreator in views.Popups)
            {
                var view = viewCreator.Create();
                _presenters.Add(popupPresenterFactory.Create(view));
            }
        }

        public void Dispose()
        {
            _presenters.ForEach(p => p.Dispose());
            _presenters.Clear();
        }
    }
}