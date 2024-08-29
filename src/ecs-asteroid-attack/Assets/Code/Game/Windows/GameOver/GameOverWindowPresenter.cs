using Code.Game.HUD.Services;
using Code.Game.Level;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;

namespace Code.Game.Windows.GameOver
{
  public class GameOverWindowPresenter : IUIViewPresenter<GameOverWindow>
  {
    private readonly IWindowService _windowService;
    private readonly IEntityFactory _entityFactory;
    private readonly IGameHUDService _gameHUDService;

    public GameOverWindowPresenter(
      IWindowService windowService, 
      IEntityFactory entityFactory,
      IGameHUDService gameHUDService)
    {
      _windowService = windowService;
      _entityFactory = entityFactory;
      _gameHUDService = gameHUDService;
    }
    
    public void OnAttach(GameOverWindow view)
    {
      view.Score.text = _gameHUDService.CurrentScore.ToString();
      view.Restart.onClick.AddListener(OnRestartClick);
      view.Exit.onClick.AddListener(OnExitClick);
    }

    public void OnDetach(GameOverWindow view)
    {
      view.Restart.onClick.RemoveListener(OnRestartClick);
      view.Exit.onClick.RemoveListener(OnExitClick);
    }
    
    private void OnExitClick()
    {
      _windowService.Pop();
      _entityFactory.CreateEntity<GameEntity>()
        .AddRoute(RouteName.MainMenu);
    }
    
    private void OnRestartClick()
    {
      _windowService.Pop();
      _entityFactory.CreateEntity<GameEntity>()
        .AddRoute(RouteName.RestartLevel);
    }
  }
}