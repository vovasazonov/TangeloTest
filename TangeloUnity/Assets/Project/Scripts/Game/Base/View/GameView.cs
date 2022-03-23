using Project.Scripts.Core.View;
using UnityEngine;

namespace Project.Scripts.Game.Base.View
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private PrimitiveView _cameraPrefab;
        [SerializeField] private PrimitiveView _eventSystemPrefab;
        
        public IViewCreator<IPrimitiveView> Camera { get; private set; }
        public IViewCreator<IPrimitiveView> EventSystem { get; private set; }

        private void Awake()
        {
            Camera = new ViewCreator<PrimitiveView>(_cameraPrefab);
            EventSystem = new ViewCreator<PrimitiveView>(_eventSystemPrefab);
        }
    }
}