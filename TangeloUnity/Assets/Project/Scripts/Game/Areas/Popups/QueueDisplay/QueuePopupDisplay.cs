using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Game.Areas.Popups.Model;

namespace Project.Scripts.Game.Areas.Popups.QueueDisplay
{
    public class QueuePopupDisplay : IQueuePopupDisplay, IDisposable
    {
        private readonly IPopupsModel _model;
        private Queue<IPopupModel> _queue = new Queue<IPopupModel>();
        private bool _isProcess;
        private IPopupModel _loadingPopup;

        public QueuePopupDisplay(IPopupsModel model)
        {
            _model = model;
        }

        public void Add(string id)
        {
            _queue.Enqueue(_model.Popups[id]);
            if (!_isProcess)
            {
                StartProcess();
            }
        }

        public void Remove(string id)
        {
            if (_loadingPopup != null && _loadingPopup.Id == id)
            {
                StopProcess();

                if (_queue.Count > 0)
                {
                    StartProcess();
                }
            }

            _queue = new Queue<IPopupModel>(_queue.Where(x => x.Id != id));
            if (_queue.Count == 0)
            {
                StopProcess();
            }
        }

        private void StartProcess()
        {
            if (_queue.Count > 0)
            {
                _isProcess = true;

                _loadingPopup = _queue.Dequeue();
                AddLoadingPopupListeners(_loadingPopup);
                _loadingPopup.OpenLoaded();
            }
        }

        private void StopProcess()
        {
            _isProcess = false;
            if (_loadingPopup != null)
            {
                RemoveLoadingPopupListeners(_loadingPopup);
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
            _queue.Enqueue(_loadingPopup);
            _loadingPopup = null;
            StartProcess();
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