using Code.Common.View.UI;

namespace Code.Infrastructure.UI
{
  public interface IUIViewPresenter<TUIView> where TUIView : IUIView
  {
    void OnAttach(TUIView view);
    
    void OnDetach(TUIView view);
  }
}