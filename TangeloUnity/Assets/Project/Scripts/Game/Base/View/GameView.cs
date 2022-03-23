using Project.Scripts.Core.View;
using Project.Scripts.Game.Areas.Popups.View;
using UnityEngine;

namespace Project.Scripts.Game.Base.View
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private PrimitiveView _cameraPrefab;
        [SerializeField] private PrimitiveView _eventSystemPrefab;
        [SerializeField] private PopupsView _popups;
        
        public IViewCreator<IPrimitiveView> Camera { get; private set; }
        public IViewCreator<IPrimitiveView> EventSystem { get; private set; }
        public IPopupsView Popups { get; private set; }

        private void Awake()
        {
            Camera = new ViewCreator<PrimitiveView>(_cameraPrefab);
            EventSystem = new ViewCreator<PrimitiveView>(_eventSystemPrefab);
            Popups = _popups;
        }
    }
}