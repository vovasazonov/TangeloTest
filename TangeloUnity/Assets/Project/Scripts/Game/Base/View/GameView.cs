using Project.Scripts.Core.View;
using Project.Scripts.Game.Areas.Popups.View;
using Project.Scripts.Game.Areas.TestScreen.View;
using UnityEngine;

namespace Project.Scripts.Game.Base.View
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private PrimitiveView _cameraPrefab;
        [SerializeField] private PrimitiveView _eventSystemPrefab;
        [SerializeField] private PopupsView _popups;
        [SerializeField] private TestScreenView _testScreenPrefab;
        
        public IViewCreator<IPrimitiveView> Camera { get; private set; }
        public IViewCreator<IPrimitiveView> EventSystem { get; private set; }
        public IPopupsView Popups { get; private set; }
        public IViewCreator<ITestScreenView> TestScreen { get; private set; }

        private void Awake()
        {
            var primitiveParent = new GameObject("primitives").transform;
            Camera = new ViewCreator<PrimitiveView>(_cameraPrefab, primitiveParent);
            EventSystem = new ViewCreator<PrimitiveView>(_eventSystemPrefab, primitiveParent);
            Popups = _popups;
            TestScreen = new ViewCreator<TestScreenView>(_testScreenPrefab);
        }
    }
}