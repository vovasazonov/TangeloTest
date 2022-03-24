using System;
using Project.Scripts.Game.Areas.Browser.Model;
using Project.Scripts.Game.Areas.Popups.Model;

namespace Project.Scripts.Game.Base.Model
{
    public class GameModel : IGameModel, IDisposable
    {
        private readonly PopupsModel _popups;
        private readonly BrowserModel _browser;
        
        public IPopupsModel Popups => _popups;
        public IBrowserModel Browser => _browser;

        public GameModel()
        {
            _popups = new PopupsModel();
            _browser = new BrowserModel();
        }

        public void Dispose()
        {
            _popups.Dispose();
        }
    }
}