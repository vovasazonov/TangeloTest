using System.Linq;
using Project.Scripts.Core.Presenter;
using Project.Scripts.Game.Areas.Browser.Model;
using Project.Scripts.Game.Areas.Popups.Model;
using Project.Scripts.Game.Areas.Popups.View;
using UnityEngine;
using UnityEngine.UI;
using ILogger = Project.Scripts.Core.Logger.ILogger;

namespace Project.Scripts.Game.Areas.Popups.Presenter
{
    public abstract class PopupPresenter : IPresenter
    {
        private readonly IPopupView _view;
        private readonly IPopupModel _model;
        private readonly IBrowserModel _browser;
        private readonly ILogger _logger;

        private int _loadedTextures;

        protected PopupPresenter(IPopupModel model, IPopupView view, IBrowserModel browser, ILogger logger)
        {
            _view = view;
            _model = model;
            _browser = browser;
            _logger = logger;

            AddListeners();
            RenderView();
        }

        private void RenderView()
        {
            _view.CloseImmediately();
        }

        private void AddListeners()
        {
            _model.Opened += OnOpened;
            _model.Closed += OnClosed;
            _model.OrderChanged += OnOrderChanged;
            _model.Loading += OnLoading;
            _model.LoadStatusUpdated += OnLoadStatusUpdated;
            _view.CloseClicked += OnCloseClicked;
            _view.UrlClicked += OnUrlClicked;
        }

        private void RemoveListeners()
        {
            _model.Opened -= OnOpened;
            _model.Closed -= OnClosed;
            _model.OrderChanged -= OnOrderChanged;
            _model.Loading -= OnLoading;
            _model.LoadStatusUpdated -= OnLoadStatusUpdated;
            _view.CloseClicked -= OnCloseClicked;
            _view.UrlClicked -= OnUrlClicked;
        }

        private void OnUrlClicked(string url)
        {
            _browser.Browse(url);
        }

        private void OnCloseClicked()
        {
            _model.Close();
        }

        private void OnClosed(IPopupModel model)
        {
            _view.Close();
        }

        private void OnOpened(IPopupModel model)
        {
            _view.Open();
        }

        private void OnOrderChanged()
        {
            _view.SetOrder(_model.Order);
        }

        private void OnLoading()
        {
            LoadView();
        }

        private void OnLoadStatusUpdated()
        {
            if (!_model.IsLoaded)
            {
                UnloadView();
            }
        }

        private bool IsViewLoaded()
        {
            return _loadedTextures == _view.UrlImages.Count();
        }

        private void SetViewLoaded()
        {
            _model.IsLoaded = true;
        }

        private void LoadView()
        {
            _loadedTextures = 0;

            foreach (var urlImage in _view.UrlImages)
            {
                _browser.Download<Texture>(urlImage.Url, t => OnSuccessLoadTexture(t, urlImage.RawImage), OnErrorLoadTexture);
            }
            
            CheckViewLoaded();
        }

        private void OnSuccessLoadTexture(Texture texture, RawImage rawImage)
        {
            ++_loadedTextures;
            rawImage.texture = texture;

            CheckViewLoaded();
        }

        private void CheckViewLoaded()
        {
            if (IsViewLoaded())
            {
                SetViewLoaded();
            }
        }

        private void OnErrorLoadTexture(string message)
        {
            _logger.LogError(message);
        }

        private void UnloadView()
        {
            foreach (var urlImage in _view.UrlImages)
            {
                urlImage.RawImage.texture = null;
            }

            _loadedTextures = 0;
        }

        public void Dispose()
        {
            UnloadView();
            RemoveListeners();
        }
    }
}