using System;
using Project.Scripts.Game.Areas.Popups.Gate;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.QueueDisplay;
using Project.Scripts.Game.Areas.Popups.Sorter;

namespace Project.Scripts.Game.Areas.Popups
{
    public class PopupsFacade : IPopups, IDisposable
    {
        private readonly PopupsSorter _sorter;
        private readonly QueuePopupDisplay _queue;
        private readonly PopupsGate _gate;

        public PopupsFacade(IPopupsModel model)
        {
            _sorter = new PopupsSorter(model);
            _queue = new QueuePopupDisplay(model);
            _gate = new PopupsGate(model);
        }

        public void Open(string id)
        {
            _gate.Open(id);
        }

        public void OpenLoaded(string id)
        {
            _gate.OpenLoaded(id);
        }

        public void Close(string id)
        {
            _gate.Close(id);
        }

        public void CloseUnloaded(string id)
        {
            _gate.CloseUnloaded(id);
        }

        public void CloseAll()
        {
            _gate.CloseAll();
        }

        public void OpenAll()
        {
            _gate.OpenAll();
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