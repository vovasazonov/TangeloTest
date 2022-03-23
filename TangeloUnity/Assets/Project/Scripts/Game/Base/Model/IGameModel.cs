using Project.Scripts.Game.Areas.Popups.Model;

namespace Project.Scripts.Game.Base.Model
{
    public interface IGameModel
    {
        IPopupsModel Popups { get; }
    }
}