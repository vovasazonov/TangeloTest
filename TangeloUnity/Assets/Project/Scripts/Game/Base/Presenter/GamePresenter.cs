using System.Collections.Generic;
using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Base.Config;
using Project.Scripts.Game.Base.Model;
using Project.Scripts.Game.Base.View;

namespace Project.Scripts.Game.Base.Presenter
{
    public class GamePresenter : IPresenter
    {
        private readonly List<IPresenter> _presenters = new List<IPresenter>();

        public GamePresenter(IGameModel model, IGameView view, IGameConfig config)
        {
            _presenters.Add(new PrimitivePresenter(view.Camera.Create()));
            _presenters.Add(new PrimitivePresenter(view.EventSystem.Create()));
        }

        public void Dispose()
        {
            _presenters.ForEach(p => p.Dispose());
            _presenters.Clear();
        }
    }
}