using Project.Scripts.Core.View;

namespace Project.Scripts.Core.Presenter
{
    public class PrimitivePresenter : IPresenter
    {
        private readonly IPrimitiveView _view;

        public PrimitivePresenter(IPrimitiveView view)
        {
            _view = view;
        }

        public void Dispose()
        {
            _view.Dispose();
        }
    }
}