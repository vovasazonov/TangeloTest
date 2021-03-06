using System;
using System.Collections;
using System.Collections.Generic;
using Project.Scripts.Core.Coroutine;
using UnityEngine;
using UnityEngine.Networking;

namespace Project.Scripts.Game.Areas.Browser.Model
{
    public class BrowserModel : IBrowserModel, IDisposable
    {
        private readonly ICoroutineFactory _coroutineFactory;
        private readonly Dictionary<int, ICoroutine> _coroutines = new Dictionary<int, ICoroutine>();
        private int _idCounter;

        public BrowserModel(ICoroutineFactory coroutineFactory)
        {
            _coroutineFactory = coroutineFactory;
        }

        public void Browse(string url)
        {
            Application.OpenURL(url);
        }

        public void Download<T>(string url, Action<T> success, Action<string> error) where T : class
        {
            ++_idCounter;
            int id = _idCounter;

            if (typeof(T) == typeof(Texture))
            {
                void SuccessDownload(Texture texture) => success.Invoke(texture as T);
                var coroutine = _coroutineFactory.Create(() => DownloadCoroutine(url, SuccessDownload, error, id));
                _coroutines.Add(id, coroutine);
                coroutine.Start();
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private IEnumerator DownloadCoroutine(string url, Action<Texture> success, Action<string> error, int id)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
            {
                yield return request.SendWebRequest();
                if (request.result != UnityWebRequest.Result.Success)
                {
                    error?.Invoke(request.result.ToString());
                }
                else
                {
                    success?.Invoke(((DownloadHandlerTexture)request.downloadHandler).texture);
                }
            }

            _coroutines.Remove(id);
        }

        public void Dispose()
        {
            foreach (var coroutines in _coroutines.Values)
            {
                coroutines.Stop();
            }

            _coroutines.Clear();
        }
    }
}