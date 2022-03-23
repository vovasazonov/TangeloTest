using System;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Base.Model;
using Project.Scripts.Game.Base.Presenter;
using Project.Scripts.Game.Base.View;

namespace Project.Scripts.Game
{
    public class Game : IDisposable
    {
        private readonly IGameModel _model;
        private readonly IGameView _view;
        private readonly IDisposable _presenter;
        private readonly PopupsModel _popups;

        public Game(IGameView view)
        {
            _view = view;
            _popups = new PopupsModel();
            _model = new GameModel(_popups);
            _presenter = new GamePresenter(_model, _view, _popups);
        }

        public void Dispose()
        {
            _presenter.Dispose();
            _popups.Dispose();
        }
    }
}