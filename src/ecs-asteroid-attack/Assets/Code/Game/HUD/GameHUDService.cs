using Code.Common.View.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;

namespace Code.Game.HUD
{
  public class GameHUDService : IUIViewService<GameHUDView>
  {
    private readonly IWindowService _windowService;

    GameHUDService(IWindowService windowService)
    {
      _windowService = windowService;
    }

    public void OnAttach(GameHUDView view)
    {
      view.Menu.onClick.AddListener(OnMenuButton);
    }

    public void OnDetach(GameHUDView view)
    {
      view.Menu.onClick.RemoveListener(OnMenuButton);
    }

    private void OnMenuButton() => _windowService.Push(WindowName.PauseWindow);
  }
}