using Code.Game.HUD.Services;
using Code.Game.Level;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;

namespace Code.Game.Windows.Pause
{
  public class PauseWindowPresenter : IUIViewPresenter<PauseWindow>
  {
    private readonly IEntityFactory _entityFactory;
    private readonly IWindowService _windowService;
    
    public PauseWindowPresenter(
      IEntityFactory entityFactory,
      IWindowService windowService)
    {
      _entityFactory = entityFactory;
      _windowService = windowService;
    }
    
    public void OnAttach(PauseWindow view)
    {
      view.Resume.onClick.AddListener(OnResumeClick);
      view.Settings.onClick.AddListener(OnSettingsClick);
      view.Exit.onClick.AddListener(OnExitClick);
    }

    public void OnDetach(PauseWindow view)
    {
      view.Resume.onClick.RemoveListener(OnResumeClick);
      view.Settings.onClick.RemoveListener(OnSettingsClick);
      view.Exit.onClick.RemoveListener(OnExitClick);
    }
    
    private void OnExitClick()
    {
      _windowService.Pop();
      _entityFactory.CreateEntity<GameEntity>()
        .AddRoute(RouteName.MainMenu);
    }
    
    private void OnResumeClick()
    {
      _windowService.Pop();
      _entityFactory.CreateEntity<GameEntity>()
        .AddRoute(RouteName.Resume);
    }

    private void OnSettingsClick() => _windowService.Push(WindowName.SettingsWindow);
  }
}