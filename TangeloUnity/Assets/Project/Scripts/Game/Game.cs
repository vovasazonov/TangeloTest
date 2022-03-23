using System;
using Project.Scripts.Game.Base.Config;
using Project.Scripts.Game.Base.Model;
using Project.Scripts.Game.Base.Presenter;
using Project.Scripts.Game.Base.View;

namespace Project.Scripts.Game
{
    public class Game : IDisposable
    {
        private readonly IGameModel _model;
        private readonly IGameConfig _config;
        private readonly IGameView _view;
        private readonly IDisposable _presenter;
        
        public Game(IGameConfig config, IGameView view)
        {
            _config = config;
            _view = view;
            _model = new GameModel(_config);
            _presenter = new GamePresenter(_model, _view, _config);
        }

        public void Dispose()
        {
            _presenter?.Dispose();
        }
    }
}