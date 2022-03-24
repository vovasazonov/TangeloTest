using Project.Scripts.Core.View;
using Project.Scripts.Game.Areas.Popups.View;
using Project.Scripts.Game.Areas.TestScreen.View;

namespace Project.Scripts.Game.Base.View
{
    public interface IGameView
    {
        IViewCreator<IPrimitiveView> Camera { get; }
        IViewCreator<IPrimitiveView> EventSystem { get; }
        IPopupsView Popups { get; }
        IViewCreator<ITestScreenView> TestScreen { get; }
    }
}