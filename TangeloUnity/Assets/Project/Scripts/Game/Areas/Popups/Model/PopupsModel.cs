using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Scripts.Game.Areas.Popups.Model
{
    public class PopupsModel : IPopupsModel, IDisposable
    {
        public event Action<string> PopupInitialized;
        
        private readonly List<IPopupModel> _opens = new List<IPopupModel>();
        private readonly Dictionary<string, IPopupModel> _popups = new Dictionary<string, IPopupModel>();

        public IReadOnlyDictionary<string, IPopupModel> Popups => _popups;

        public PopupsModel()
        {
        }

        public PopupsModel(IEnumerable<string> ids)
        {
            _popups = ids.ToDictionary(c => c, c => new PopupModel(c) as IPopupModel);
            
            AddListeners();
        }

        public void Initialize(string id)
        {
            _popups.Add(id, new PopupModel(id));
            CallInitialized(id);
        }

        private void AddListeners()
        {
            foreach (var popup in Popups.Values)
            {
                AddPopupListenerListeners(popup);
            }
        }

        private void RemoveListeners()
        {
            foreach (var popup in Popups.Values)
            {
                RemovePopupListenerListeners(popup);
            }
        }

        private void AddPopupListenerListeners(IPopupModel popup)
        {
            popup.Opened += OnOpened;
            popup.Closed += OnClosed;
        }

        private void RemovePopupListenerListeners(IPopupModel popup)
        {
            popup.Opened -= OnOpened;
            popup.Closed -= OnClosed;
        }

        private void OnClosed(IPopupModel model)
        {
            _opens.Remove(model);
        }

        private void OnOpened(IPopupModel model)
        {
            if (!_opens.Contains(model))
            {
                _opens.Add(model);
            }
        }

        public void Dispose()
        {
            RemoveListeners();
        }

        private void CallInitialized(string id)
        {
            PopupInitialized?.Invoke(id);
        }
    }
}