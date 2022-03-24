using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.View;

namespace Project.Scripts.Game.Areas.Popups.Presenter
{
    public abstract class PopupPresenter : IPresenter
    {
        private readonly IPopupView _view;
        private readonly IPopupModel _model;

        protected PopupPresenter(IPopupModel model, IPopupView view)
        {
            _view = view;
            _model = model;
            
            AddListeners();
            RenderView();
        }

        private void RenderView()
        {
            _view.Close();
        }

        private void AddListeners()
        {
            _model.Opened += OnOpened;
            _model.Closed += OnClosed;
            _model.OrderChanged += OnOrderChanged;
            _model.Loading += OnLoading;
            _model.LoadStatusUpdated += OnLoadStatusUpdated;
            _view.CloseClicked += OnCloseClicked;
        }

        private void RemoveListeners()
        {
            _model.Opened -= OnOpened;
            _model.Closed -= OnClosed;
            _model.OrderChanged -= OnOrderChanged;
            _model.Loading -= OnLoading;
            _model.LoadStatusUpdated -= OnLoadStatusUpdated;
            _view.CloseClicked -= OnCloseClicked;
        }

        private void OnCloseClicked()
        {
            _model.Close();
        }

        private void OnClosed(IPopupModel model)
        {
            _view.Close();
        }

        private void OnOpened(IPopupModel model)
        {
            _view.Open();
        }

        private void OnOrderChanged()
        {
            _view.SetOrder(_model.Order);
        }

        private void OnLoading()
        {
            LoadView();
        }

        private void OnLoadStatusUpdated()
        {
            if (!_model.IsLoaded)
            {
                UnloadView();
            }
        }

        protected void OnViewLoaded()
        {
            _model.IsLoaded = true;
        }

        protected abstract void LoadView();
        protected abstract void UnloadView();
        
        public void Dispose()
        {
            UnloadView();
            RemoveListeners();
        }
    }
}