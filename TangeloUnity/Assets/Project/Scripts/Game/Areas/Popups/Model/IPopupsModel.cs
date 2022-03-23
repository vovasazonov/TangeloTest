using System.Collections.Generic;

namespace Project.Scripts.Game.Areas.Popups.Model
{
    public interface IPopupsModel
    {
        IReadOnlyDictionary<string, IPopupModel> Popups { get; }
        void Initialize(string id);
    }
}