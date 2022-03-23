using System;
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
        
        public Game(IGameView view)
        {
            _view = view;
            _model = new GameModel();
            _presenter = new GamePresenter(_model, _view);
        }

        public void Dispose()
        {
            _presenter?.Dispose();
        }
    }
}