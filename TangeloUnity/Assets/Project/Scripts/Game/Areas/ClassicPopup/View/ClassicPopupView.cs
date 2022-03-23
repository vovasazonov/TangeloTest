using Project.Scripts.Game.Areas.Popups.View;

namespace Project.Scripts.Game.Areas.ClassicPopup.View
{
    public class ClassicPopupView : PopupView
    {
        public override void Open()
        {
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }
    }
}