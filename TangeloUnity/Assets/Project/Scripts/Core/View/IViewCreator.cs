using System;

namespace Project.Scripts.Core.View
{
    public interface IViewCreator<out T> where T : IDisposable
    {
        T Create();
    }
}