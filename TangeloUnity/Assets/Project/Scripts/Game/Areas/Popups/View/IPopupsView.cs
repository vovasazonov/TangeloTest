using System.Collections.Generic;
using Project.Scripts.Core.View;

namespace Project.Scripts.Game.Areas.Popups.View
{
    public interface IPopupsView
    {
        IEnumerable<IViewCreator<IPopupView>> Popups { get; }
    }
}