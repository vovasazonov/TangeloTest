namespace Project.Scripts.Game.Areas.Popups.Model.Sorter
{
    public interface IPopupsSorter
    {
        void Sort(IPopupModel model);
        void UnSort(IPopupModel model);
        void Clear();
    }
}