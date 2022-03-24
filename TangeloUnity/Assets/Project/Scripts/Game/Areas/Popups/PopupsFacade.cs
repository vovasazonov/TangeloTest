using System;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.QueueDisplay;
using Project.Scripts.Game.Areas.Popups.Sorter;

namespace Project.Scripts.Game.Areas.Popups
{
    public class PopupsFacade : IPopups, IDisposable
    {
        private readonly IPopupsModel _model;
        private readonly PopupsSorter _sorter;
        private readonly QueuePopupDisplay _queue;

        public PopupsFacade(IPopupsModel model)
        {
            _model = model;
            _sorter = new PopupsSorter(model);
            _queue = new QueuePopupDisplay(model);
        }

        public void Open(string id)
        {
            _model.Popups[id].Open();
        }

        public void OpenLoaded(string id)
        {
            _model.Popups[id].OpenLoaded();
        }

        public void Close(string id)
        {
            _model.Popups[id].Close();
        }

        public void CloseUnloaded(string id)
        {
            _model.Popups[id].CloseUnloaded();
        }

        public void CloseAll()
        {
            foreach (var popup in _model.Popups.Values)
            {
                if (popup.IsOpen)
                {
                    popup.Close();
                }
            }
        }

        public void OpenAll()
        {
            foreach (var popup in _model.Popups.Values)
            {
                if (!popup.IsOpen)
                {
                    popup.Open();
                }
            }
        }

        public void AddToQueueDisplay(string id)
        {
            _queue.Add(id);
        }

        public void RemoveFromQueueDisplay(string id)
        {
            _queue.Remove(id);
        }

        public void Dispose()
        {
            _sorter.Dispose();
            _queue.Dispose();
        }
    }
}