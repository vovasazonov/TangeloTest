using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Game.Areas.Popups.Model.Sorter;

namespace Project.Scripts.Game.Areas.Popups.Model
{
    public class PopupsModel : IPopupsModel, IDisposable, IPopups
    {
        private readonly List<IPopupModel> _opens = new List<IPopupModel>();
        private readonly IPopupsSorter _sorter = new PopupsSorter();

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
            _sorter.UnSort(model);
        }

        private void OnOpened(IPopupModel model)
        {
            if (!_opens.Contains(model))
            {
                _opens.Add(model);
                _sorter.Sort(model);
            }
        }
        
        public void Open(string id)
        {
            _popups[id].Open();
        }

        public void Close(string id)
        {
            _popups[id].Close();
        }

        public void CloseAll()
        {
            foreach (var popup in _popups.Values)
            {
                if (popup.IsOpen)
                {
                    popup.Close();
                }
            }
        }

        public void OpenAll()
        {
            foreach (var popup in _popups.Values)
            {
                if (!popup.IsOpen)
                {
                    popup.Open();
                }
            }
        }

        public void Dispose()
        {
            RemoveListeners();
            _sorter.Clear();
        }
    }
}