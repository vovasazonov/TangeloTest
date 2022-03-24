using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Areas.TestMenu.View
{
    public class TestScreenView : MonoBehaviour, ITestScreenView
    {
        public event Action<string> OpenPopupClicked;
        public event Action OpenAllPopupsClicked;

        [SerializeField] private Button _openAllPopupsButton;
        [SerializeField] private List<PopupButton> _openPopupButtons;
        private bool _isDestroyed;

        private void OnEnable()
        {
            _openAllPopupsButton.onClick.AddListener(CallOpenAllPopupsClicked);
            _openPopupButtons.ForEach(i => i.Button.onClick.AddListener(() => CallOpenPopupClicked(i.Id)));
        }

        private void OnDisable()
        {
            _openAllPopupsButton.onClick.RemoveListener(CallOpenAllPopupsClicked);
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