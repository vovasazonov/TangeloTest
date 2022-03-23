using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Scripts.Core.View
{
    public class ViewCreator<T> : IViewCreator<T> where T : MonoBehaviour, IDisposable
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly bool _containsParent;
        
        public ViewCreator(T prefab)
        {
            _prefab = prefab;
        }

        public ViewCreator(T prefab, Transform parent)
        {
            _containsParent = true;
            _prefab = prefab;
            _parent = parent;
        }
        
        public T Create()
        {
            return _containsParent ? Object.Instantiate(_prefab, _parent) : Object.Instantiate(_prefab);
        }
    }
}