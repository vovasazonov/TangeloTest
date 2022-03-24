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
        [SerializeField] protected List<UrlButton> _urlButtons;

        public event Action CloseClicked;
        public event Action<string> UrlClicked;

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
            _urlButtons.ForEach(i => i.Button.onClick.AddListener(() => CallUrlClicked(i.Url)));
        }

        private void OnDisable()
        {
            _closeButtons.ForEach(i => i.onClick.RemoveListener(CallCloseClicked));
            _urlButtons.ForEach(i => i.Button.onClick.RemoveAllListeners());
        }

        private void CallCloseClicked()
        {
            CloseClicked?.Invoke();
        }

        private void CallUrlClicked(string url)
        {
            UrlClicked?.Invoke(url);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        [Serializable] protected struct UrlButton
        {
            public string Url;
            public Button Button;
        }
    }
}