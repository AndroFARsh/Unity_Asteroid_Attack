namespace Code.Common.View.UI
{
  public interface IUIViewService<TUIView> where TUIView : IUIView
  {
    void OnAttach(TUIView view);
    
    void OnDetach(TUIView view);
  }
}