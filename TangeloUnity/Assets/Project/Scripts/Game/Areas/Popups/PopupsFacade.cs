using Project.Scripts.Game.Areas.Popups.Model;

namespace Project.Scripts.Game.Areas.Popups
{
    public class PopupsFacade : IPopupsFacade
    {
        private readonly IPopupsModel _model;

        public PopupsFacade(IPopupsModel model)
        {
            _model = model;
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
    }
}