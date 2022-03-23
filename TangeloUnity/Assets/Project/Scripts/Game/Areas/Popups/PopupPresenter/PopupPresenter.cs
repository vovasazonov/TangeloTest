using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.View;

namespace Project.Scripts.Game.Areas.Popups.PopupPresenter
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
        }

        private void AddListeners()
        {
            _model.Opened += OnOpened;
            _model.Closed += OnClosed;
            _model.OrderChanged += OnOrderChanged;
        }

        private void RemoveListeners()
        {
            _model.Opened -= OnOpened;
            _model.Closed -= OnClosed;
            _model.OrderChanged -= OnOrderChanged;
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
        
        public void Dispose()
        {
            RemoveListeners();
        }
    }
}