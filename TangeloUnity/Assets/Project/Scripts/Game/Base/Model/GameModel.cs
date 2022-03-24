using System;
using Project.Scripts.Game.Areas.Popups.Model;

namespace Project.Scripts.Game.Base.Model
{
    public class GameModel : IGameModel, IDisposable
    {
        private readonly PopupsModel _popups;
        
        public IPopupsModel Popups => _popups;

        public GameModel()
        {
            _popups = new PopupsModel();
        }

        public void Dispose()
        {
            _popups.Dispose();
        }
    }
}