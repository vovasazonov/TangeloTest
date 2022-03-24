using Project.Scripts.Game.Areas.Popups.Model;

namespace Project.Scripts.Game.Areas.Popups.Gate
{
    public class PopupsGate : IPopupsGate
    {
        private readonly IPopupsModel _model;

        public PopupsGate(IPopupsModel model)
        {
            _model = model;
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
                    popup.Load();
                    popup.Open();
                }
            }
        }
    }
}