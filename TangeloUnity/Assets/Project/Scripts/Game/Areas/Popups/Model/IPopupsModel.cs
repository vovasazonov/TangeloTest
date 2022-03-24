using System;
using System.Collections.Generic;

namespace Project.Scripts.Game.Areas.Popups.Model
{
    public interface IPopupsModel
    {
        event Action<string> PopupInitialized;
        IReadOnlyDictionary<string, IPopupModel> Popups { get; }
        void Initialize(string id);
    }
}