using Code.Common.View.UI;

namespace Code.Infrastructure.Windows
{
  public interface IWindow : IUIView
  {
    void Resume();
    void Pause();
  }
}