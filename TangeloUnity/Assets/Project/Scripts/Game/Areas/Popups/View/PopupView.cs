using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Areas.Popups.View
{
    public abstract class PopupView : MonoBehaviour, IPopupView
    {
        [SerializeField] private string _id;
        [SerializeField] protected Canvas _canvas;
        [SerializeField] protected GraphicRaycaster _raycaster;

        public string Id => _id;
        
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