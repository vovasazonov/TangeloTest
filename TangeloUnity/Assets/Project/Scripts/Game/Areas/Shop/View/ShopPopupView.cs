using Project.Scripts.Game.Areas.Popups.View;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Shop.View
{
    public class ShopPopupView : PopupView, IShopPopupView
    {
        [SerializeField] private TextMeshProUGUI _availableCoinsText;
        
        public int AvailableCoins
        {
            set => _availableCoinsText.text = value.ToString();
        }
    }
}