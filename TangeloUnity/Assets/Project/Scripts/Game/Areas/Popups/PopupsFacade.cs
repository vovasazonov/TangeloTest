using System;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.Sorter;

namespace Project.Scripts.Game.Areas.Popups
{
    public class PopupsFacade : IPopups, IDisposable
    {
        private readonly IPopupsModel _model;
        private readonly PopupsSorter _sorter;

        public PopupsFacade(IPopupsModel model)
        {
            _model = model;
            _sorter = new PopupsSorter(model);
        }

        public void Open(string id)
        {
            _model.Popups[id].Open();
        }

        public void Close(string id)
        {
            _model.Popups[id].Close();
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

        public void Dispose()
        {
            _sorter.Dispose();
        }
    }
}