using System.Collections.Generic;
using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Areas.Popups.PopupPresenter;
using Project.Scripts.Game.Areas.PopupsFactory;
using Project.Scripts.Game.Base.Model;
using Project.Scripts.Game.Base.View;

namespace Project.Scripts.Game.Base.Presenter
{
    public class GamePresenter : IPresenter
    {
        private readonly List<IPresenter> _presenters = new List<IPresenter>();

        public GamePresenter(IGameModel model, IGameView view)
        {
            _presenters.Add(new PrimitivePresenter(view.Camera.Create()));
            _presenters.Add(new PrimitivePresenter(view.EventSystem.Create()));
            _presenters.Add(new PopupsPresenter(new PopupPresenterFactory(model.Popups), view.Popups));
        }

        public void Dispose()
        {
            _presenters.ForEach(p => p.Dispose());
            _presenters.Clear();
        }
    }
}