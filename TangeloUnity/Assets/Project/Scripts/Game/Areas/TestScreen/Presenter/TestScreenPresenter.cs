using Project.Scripts.Core.Presenter;
using Project.Scripts.Core.View;
using Project.Scripts.Game.Areas.Popups;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.TestScreen.View;

namespace Project.Scripts.Game.Areas.TestScreen.Presenter
{
    public class TestScreenPresenter : IPresenter
    {
        private readonly ITestScreenView _view;
        private readonly IPopups _popups;
        private readonly IPopupsModel _popupsModel;

        public TestScreenPresenter(IViewCreator<ITestScreenView> view, IPopups popups, IPopupsModel popupsModel)
        {
            _view = view.Create();
            _popups = popups;
            _popupsModel = popupsModel;

            AddListeners();
        }

        private void AddListeners()
        {
            _view.OpenPopupClicked += OnOpenPopupClicked;
            _view.OpenAllPopupsClicked += OnOpenAllPopupsClicked;
            _view.QueueAllPopupsClicked += OnQueueAllPopupsClicked;
        }

        private void RemoveListeners()
        {
            _view.OpenPopupClicked -= OnOpenPopupClicked;
            _view.OpenAllPopupsClicked -= OnOpenAllPopupsClicked;
            _view.QueueAllPopupsClicked -= OnQueueAllPopupsClicked;
        }

        private void OnQueueAllPopupsClicked()
        {
            foreach (var id in _popupsModel.Popups.Keys)
            {
                _popups.QueueDisplay(id);
            }
        }

        private void OnOpenPopupClicked(string id)
        {
            _popups.OpenLoaded(id);
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