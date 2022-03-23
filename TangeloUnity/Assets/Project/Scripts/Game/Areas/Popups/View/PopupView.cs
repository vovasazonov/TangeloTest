using UnityEngine;

namespace Project.Scripts.Game.Areas.Popups.View
{
    [RequireComponent(typeof(Canvas))]
    public abstract class PopupView : MonoBehaviour, IPopupView
    {
        [SerializeField] private string _id;

        private Canvas _canvas;

        public string Id => _id;
        
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        public void SetOrder(int order)
        {
            _canvas.sortingOrder = order;
        }

        public abstract void Open();
        public abstract void Close();

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}