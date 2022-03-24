using Project.Scripts.Game.Areas.Popups.View;

namespace Project.Scripts.Game.Areas.ClassicPopup.View
{
    public class ClassicPopupView : PopupView
    {
        public override void Open()
        {
            _canvas.enabled = true;
            _raycaster.enabled = true;
        }

        public override void Close()
        {
            _canvas.enabled = false;
            _raycaster.enabled = false;
        }
    }
}