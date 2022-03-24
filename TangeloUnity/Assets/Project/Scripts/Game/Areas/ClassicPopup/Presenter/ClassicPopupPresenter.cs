using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.Presenter;
using Project.Scripts.Game.Areas.Popups.View;

namespace Project.Scripts.Game.Areas.ClassicPopup.Presenter
{
    public class ClassicPopupPresenter : PopupPresenter
    {
        public ClassicPopupPresenter(IPopupModel model, IPopupView view) : base(model, view)
        {
        }

        protected override void LoadView()
        {
        }

        protected override void UnloadView()
        {
        }
    }
}