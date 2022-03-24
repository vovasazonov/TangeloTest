using System;
using System.Collections;

namespace Project.Scripts.Core.Coroutine
{
    public interface ICoroutineFactory
    {
        ICoroutine Create(Func<IEnumerator> enumeratorGetter);
    }
}