using System;

namespace Project.Scripts.Game.Areas.Popups.Model
{
    public class PopupModel : IPopupModel
    {
        public event Action<IPopupModel> Opened;
        public event Action<IPopupModel> Closed;
        public event Action OrderChanged;
        public event Action LoadStatusUpdated;
        public event Action Loading;

        private int _order;
        private bool _isLoaded;
        private bool _isOpenOnLoad;

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

        public bool IsLoaded
        {
            get => _isLoaded;
            set
            {
                _isLoaded = value;
                LoadStatusUpdated?.Invoke();

                if (_isOpenOnLoad && _isLoaded)
                {
                    Open();
                }
            }
        }

        public PopupModel(string id)
        {
            Id = id;
        }

        public void Open()
        {
            IsOpen = true;
            _isOpenOnLoad = false;
            Opened?.Invoke(this);
        }

        public void Close()
        {
            IsOpen = false;
            Closed?.Invoke(this);
        }

        public void Load()
        {
            Loading?.Invoke();
        }

        public void Unload()
        {
            IsLoaded = false;
        }

        public void OpenLoaded()
        {
            _isOpenOnLoad = true;
            Load();
        }

        public void CloseUnloaded()
        {
            Unload();
            Close();
        }
    }
}