using UnityEngine;

namespace Project.Scripts.Game.Areas.Browser.Model
{
    public class BrowserModel : IBrowserModel
    {
        public void Browse(string url)
        {
            Application.OpenURL(url);
        }
    }
}