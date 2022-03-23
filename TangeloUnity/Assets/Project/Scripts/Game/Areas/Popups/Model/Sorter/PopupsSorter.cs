using System.Collections.Generic;

namespace Project.Scripts.Game.Areas.Popups.Model.Sorter
{
    public class PopupsSorter : IPopupsSorter
    {
        private readonly IDictionary<int, IPopupModel> _popupByOrder = new Dictionary<int, IPopupModel>();
        private readonly IDictionary<IPopupModel, int> _orderByPopup = new Dictionary<IPopupModel, int>();
        private int _maximum;
        
        public void Sort(IPopupModel model)
        {
            ++_maximum;
            AddModel(_maximum, model);
        }

        public void UnSort(IPopupModel model)
        {
            int order = _orderByPopup[model];
            _popupByOrder.Remove(order);
            _orderByPopup.Remove(model);

            SortToMissingOrder(order);

            --_maximum;
        }

        private void SortToMissingOrder(int order)
        {
            int startOrderToSort = order + 1;
            for (int i = startOrderToSort; i < _maximum; i++)
            {
                var modelToSort = _popupByOrder[i];
                int orderToSort = _orderByPopup[modelToSort];

                RemoveModel(orderToSort, modelToSort);

                --orderToSort;

                AddModel(orderToSort, modelToSort);
            }
        }

        private void AddModel(int order, IPopupModel model)
        {
            _popupByOrder.Add(order, model);
            _orderByPopup.Add(model, order);
            model.Order = order;
        }

        private void RemoveModel(int order, IPopupModel model)
        {
            _popupByOrder.Remove(order);
            _orderByPopup.Remove(model);
        }

        public void Clear()
        {
            _popupByOrder.Clear();
            _orderByPopup.Clear();
            _maximum = 0;
        }
    }
}