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
        [SerializeField] protected Animator _animator;
        [SerializeField] protected List<Button> _closeButtons;
        [SerializeField] protected List<UrlButton> _urlButtons;
        [SerializeField] protected List<UrlImage> _urlTextures;
        
        private bool _isDestroyed;

        public event Action CloseClicked;
        public event Action<string> UrlClicked;
        public event Action Disappeared;

        public string Id => _id;
        public IEnumerable<UrlImage> UrlImages => _urlTextures;

        public void SetOrder(int order)
        {
            _canvas.sortingOrder = order;
        }

        public void Open()
        {
            _raycaster.enabled = true;
            _canvas.enabled = true;
            if (_animator != null)
            {
                _animator.Play("OpenPopup");
            }
        }

        public void Close()
        {
            if (_animator != null)
            {
                _raycaster.enabled = false;
                _animator.Play("ClosePopup");
            }
            else
            {
                CloseImmediately();
            }
        }

        public void CloseImmediately()
        {
            _raycaster.enabled = false;
            _canvas.enabled = false;
            Disappeared?.Invoke();
        }

        public void UnloadUrlImages()
        {
            if (!_isDestroyed)
            {
                foreach (var urlImage in _urlTextures)
                {
                    var texture = urlImage.RawImage.texture;
                    if (texture != null)
                    {
                        Destroy(texture);
                        urlImage.RawImage.texture = null;
                    }
                }
            }
        }

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

        private void OnDestroy()
        {
            _isDestroyed = true;
        }

        [Serializable] 
        protected struct UrlButton
        {
            public string Url;
            public Button Button;
        }
    }
}