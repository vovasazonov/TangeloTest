using Project.Scripts.Game.Areas.Popups.Model;

namespace Project.Scripts.Game.Base.Model
{
    public class GameModel : IGameModel
    {
        public IPopupsModel Popups { get; }

        public GameModel(IPopupsModel popups)
        {
            Popups = popups;
        }
    }
}