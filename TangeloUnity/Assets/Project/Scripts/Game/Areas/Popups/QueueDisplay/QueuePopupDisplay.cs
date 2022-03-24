using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Popups.Model;

namespace Project.Scripts.Game.Areas.Popups.QueueDisplay
{
    public class QueuePopupDisplay : IQueuePopupDisplay, IDisposable
    {
        private readonly IPopupsModel _model;
        private readonly Queue<IPopupModel> _queue = new Queue<IPopupModel>();
        private bool _isProcess;
        private IPopupModel _loadingPopup;

        public QueuePopupDisplay(IPopupsModel model)
        {
            _model = model;
        }

        public void Enqueue(string id)
        {
            _queue.Enqueue(_model.Popups[id]);
            if (!_isProcess)
            {
                Process();
            }
        }

        private void Process()
        {
            if (_queue.Count > 0)
            {
                _isProcess = true;
                _loadingPopup = _queue.Dequeue();
                AddLoadingPopupListeners(_loadingPopup);
                _loadingPopup.OpenLoaded();
            }
            else
            {
                _isProcess = false;
            }
        }

        private void AddLoadingPopupListeners(IPopupModel model)
        {
            model.LoadStatusUpdated += OnLoadStatusUpdated;
            model.Closed += OnClosed;
        }

        private void RemoveLoadingPopupListeners(IPopupModel model)
        {
            model.LoadStatusUpdated -= OnLoadStatusUpdated;
            model.Closed -= OnClosed;
        }

        private void OnClosed(IPopupModel model)
        {
            RemoveLoadingPopupListeners(_loadingPopup);
            _loadingPopup = null;
            Process();
        }

        private void OnLoadStatusUpdated()
        {
            if (_loadingPopup.IsLoaded)
            {
                _loadingPopup.Open();
            }
        }

        public void Dispose()
        {
            _queue.Clear();
        }
    }
}