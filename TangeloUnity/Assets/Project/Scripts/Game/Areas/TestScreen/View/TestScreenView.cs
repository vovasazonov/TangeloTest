using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Areas.TestScreen.View
{
    public class TestScreenView : MonoBehaviour, ITestScreenView
    {
        public event Action<string> OpenPopupClicked;
        public event Action OpenAllPopupsClicked;
        public event Action QueueAllPopupsClicked;

        [SerializeField] private Button _openAllPopupsButton;
        [SerializeField] private Button _queueAllPopupsButton;
        [SerializeField] private List<PopupButton> _openPopupButtons;
        private bool _isDestroyed;

        private void OnEnable()
        {
            _openAllPopupsButton.onClick.AddListener(CallOpenAllPopupsClicked);
            _queueAllPopupsButton.onClick.AddListener(CallQueueAllPopupsClicked);
            _openPopupButtons.ForEach(i => i.Button.onClick.AddListener(() => CallOpenPopupClicked(i.Id)));
        }

        private void OnDisable()
        {
            _openAllPopupsButton.onClick.RemoveListener(CallOpenAllPopupsClicked);
            _queueAllPopupsButton.onClick.RemoveListener(CallQueueAllPopupsClicked);
            _openPopupButtons.ForEach(i => i.Button.onClick.RemoveListener(() => CallOpenPopupClicked(i.Id)));
        }

        private void CallOpenPopupClicked(string id)
        {
            OpenPopupClicked?.Invoke(id);
        }

        private void CallOpenAllPopupsClicked()
        {
            OpenAllPopupsClicked?.Invoke();
        }

        private void CallQueueAllPopupsClicked()
        {
            QueueAllPopupsClicked?.Invoke();
        }

        public void Dispose()
        {
            if (!_isDestroyed)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            _isDestroyed = true;
        }

        [Serializable] private struct PopupButton
        {
            public string Id;
            public Button Button;
        }
    }
}