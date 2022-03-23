using Project.Scripts.Core.View;

namespace Project.Scripts.Game.Base.View
{
    public interface IGameView
    {
        IViewCreator<IPrimitiveView> Camera { get; }
        IViewCreator<IPrimitiveView> EventSystem { get; }
    }
}