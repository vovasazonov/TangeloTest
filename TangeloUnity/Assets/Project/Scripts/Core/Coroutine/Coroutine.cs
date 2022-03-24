using System;
using System.Collections;
using UnityEngine;

namespace Project.Scripts.Core.Coroutine
{
    public class Coroutine : ICoroutine
    {
        private readonly MonoBehaviour _monoBehaviour;
        private readonly Func<IEnumerator> _enumeratorGetter;
        private UnityEngine.Coroutine _coroutine;

        public Coroutine(MonoBehaviour monoBehaviour, Func<IEnumerator> enumeratorGetter)
        {
            _monoBehaviour = monoBehaviour;
            _enumeratorGetter = enumeratorGetter;
        }

        public void Start()
        {
            Stop();
            IEnumerator enumerator = _enumeratorGetter.Invoke();
            _coroutine = _monoBehaviour.StartCoroutine(enumerator);
        }

        public void Stop()
        {
            if (_coroutine != null)
            {
                _monoBehaviour.StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }
}