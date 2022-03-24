using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Areas.Popups.View
{
    public abstract class PopupView : MonoBehaviour, IPopupView
    {
        [SerializeField] private string _id;
        [SerializeField] protected Canvas _canvas;
        [SerializeField] protected GraphicRaycaster _raycaster;
        [SerializeField] protected List<Button> _closeButtons;

        public event Action CloseClicked;

        public string Id => _id;

        public void SetOrder(int order)
        {
            _canvas.sortingOrder = order;
        }

        public abstract void Open();
        public abstract void Close();

        private void OnEnable()
        {
            _closeButtons.ForEach(i => i.onClick.AddListener(CallCloseClicked));
        }

        private void OnDisable()
        {
            _closeButtons.ForEach(i => i.onClick.RemoveListener(CallCloseClicked));
        }

        private void CallCloseClicked()
        {
            CloseClicked?.Invoke();
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}