using UnityEngine;

namespace Project.Scripts.Core.View
{
    public class PrimitiveView : MonoBehaviour, IPrimitiveView
    {
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}