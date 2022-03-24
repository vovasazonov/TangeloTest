using Project.Scripts.Core.Presenter;
using Project.Scripts.Core.View;
using Project.Scripts.Game.Areas.Popups;
using Project.Scripts.Game.Areas.TestScreen.View;

namespace Project.Scripts.Game.Areas.TestScreen.Presenter
{
    public class TestScreenPresenter : IPresenter
    {
        private readonly ITestScreenView _view;
        private readonly IPopups _popups;

        public TestScreenPresenter(IViewCreator<ITestScreenView> view, IPopups popups)
        {
            _view = view.Create();
            _popups = popups;
            
            AddListeners();
        }

        private void AddListeners()
        {
            _view.OpenPopupClicked += OnOpenPopupClicked;
            _view.OpenAllPopupsClicked += OnOpenAllPopupsClicked;
        }

        private void RemoveListeners()
        {
            _view.OpenPopupClicked -= OnOpenPopupClicked;
            _view.OpenAllPopupsClicked -= OnOpenAllPopupsClicked;
        }

        private void OnOpenPopupClicked(string id)
        {
            _popups.Open(id);
        }

        private void OnOpenAllPopupsClicked()
        {
            _popups.OpenAll();
        }

        public void Dispose()
        {
            RemoveListeners();
            _view.Dispose();
        }
    }
}