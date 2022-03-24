using UnityEngine;

namespace Project.Scripts.Core.View
{
    public class PrimitiveView : MonoBehaviour, IPrimitiveView
    {
        private bool _isDestroyed;
        
        public void Dispose()
        {
            if (!_isDestroyed)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            _isDestroyed = true;
        }
    }
}