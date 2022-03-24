using System;
using Project.Scripts.Core.Coroutine;
using Project.Scripts.Game.Areas.Popups;
using Project.Scripts.Game.Base.Model;
using Project.Scripts.Game.Base.Presenter;
using Project.Scripts.Game.Base.View;

namespace Project.Scripts.Game
{
    public class Game : IDisposable
    {
        private readonly IGameView _view;
        private readonly GameModel _model;
        private readonly IDisposable _presenter;

        public Game(IGameView view, ICoroutineFactory coroutineFactory)
        {
            _view = view;
            _model = new GameModel(coroutineFactory);
            var popups = new PopupsFacade(_model.Popups);
            _presenter = new GamePresenter(_model, _view, popups);
        }

        public void Dispose()
        {
            _presenter.Dispose();
            _model.Dispose();
        }
    }
}