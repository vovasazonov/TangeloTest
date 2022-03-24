using System;
using System.Collections;
using UnityEngine;

namespace Project.Scripts.Core.Coroutine
{
    public class CoroutineFactory : ICoroutineFactory
    {
        private readonly MonoBehaviour _monoBehaviour;

        public CoroutineFactory(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }

        public ICoroutine Create(Func<IEnumerator> enumeratorGetter)
        {
            return new Coroutine(_monoBehaviour, enumeratorGetter);
        }
    }
}