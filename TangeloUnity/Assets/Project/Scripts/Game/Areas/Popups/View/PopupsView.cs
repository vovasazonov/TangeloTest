using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Core.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Popups.View
{
    public class PopupsView : MonoBehaviour, IPopupsView
    {
        [SerializeField] private List<PopupView> _popupPrefabs;

        public IEnumerable<IViewCreator<IPopupView>> Popups => _popupPrefabs.Select(v => new ViewCreator<PopupView>(v));
    }
}