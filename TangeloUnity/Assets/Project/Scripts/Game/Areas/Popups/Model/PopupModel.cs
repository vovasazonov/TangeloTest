using System;

namespace Project.Scripts.Game.Areas.Popups.Model
{
    public class PopupModel : IPopupModel
    {
        public event Action<IPopupModel> Opened;
        public event Action<IPopupModel> Closed;
        public event Action OrderChanged;

        private int _order;

        public string Id { get; }

        public int Order
        {
            get => _order;
            set
            {
                _order = value;
                OrderChanged?.Invoke();
            }
        }

        public bool IsOpen { get; private set; }

        public PopupModel(string id)
        {
            Id = id;
        }

        public void Open()
        {
            IsOpen = true;
            Opened?.Invoke(this);
        }

        public void Close()
        {
            IsOpen = false;
            Closed?.Invoke(this);
        }
    }
}