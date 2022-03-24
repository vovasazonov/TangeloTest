using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Popups.Model;

namespace Project.Scripts.Game.Areas.Popups.Sorter
{
    public class PopupsSorter : IDisposable
    {
        private readonly IPopupsModel _model;
        private readonly IDictionary<int, IPopupModel> _popupByOrder = new Dictionary<int, IPopupModel>();
        private readonly IDictionary<IPopupModel, int> _orderByPopup = new Dictionary<IPopupModel, int>();
        private int _maximum;

        public PopupsSorter(IPopupsModel model)
        {
            _model = model;

            foreach (var id in model.Popups.Keys)
            {
                AddPopupListeners(id);
            }
            
            AddListeners();
        }

        private void AddListeners()
        {
            _model.PopupInitialized += OnPopupInitialized;
        }

        private void RemoveListeners()
        {
            _model.PopupInitialized -= OnPopupInitialized;
        }

        private void OnPopupInitialized(string id)
        {
            AddPopupListeners(id);
        }

        private void AddPopupListeners(string id)
        {
            var popup = _model.Popups[id];
            
            popup.Opened += OnOpened;
            popup.Closed += OnClosed;
        }

        private void RemovePopupListeners(string id)
        {
            var popup = _model.Popups[id];

            popup.Opened -= OnOpened;
            popup.Closed -= OnClosed;
        }

        private void OnOpened(IPopupModel model)
        {
            Sort(model);
        }

        private void OnClosed(IPopupModel model)
        {
            UnSort(model);
        }

        private void Sort(IPopupModel model)
        {
            ++_maximum;
            AddModel(_maximum, model);
        }

        private void UnSort(IPopupModel model)
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

        public void Dispose()
        {
            foreach (var id in _model.Popups.Keys)
            {
                RemovePopupListeners(id);
            }
            RemoveListeners();
            _popupByOrder.Clear();
            _orderByPopup.Clear();
            _maximum = 0;
        }
    }
}