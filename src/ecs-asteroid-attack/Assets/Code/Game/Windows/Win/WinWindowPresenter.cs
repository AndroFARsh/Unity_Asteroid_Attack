using Code.Game.HUD.Services;
using Code.Game.Level;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;
using Code.Levels.Services;

namespace Code.Game.Windows.Win
{
  public class WinWindowPresenter : IUIViewPresenter<WinWindow>
  {
    private readonly IEntityFactory _entityFactory;
    private readonly IWindowService _windowService;
    private readonly IGameHUDService _gameHUDService;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IStaticDataService _staticDataService;

    public WinWindowPresenter(
      IEntityFactory entityFactory,
      IWindowService windowService,
      IGameHUDService gameHUDService,
      ILevelDataProvider levelDataProvider,
      IStaticDataService staticDataService
    )
    {
      _entityFactory = entityFactory;
      _windowService = windowService;
      _gameHUDService = gameHUDService;
      _levelDataProvider = levelDataProvider;
      _staticDataService = staticDataService;
    }

    public void OnAttach(WinWindow view)
    {
      int nextLevel = _levelDataProvider.LevelConfig.Number + 1;
      bool lastLevel = nextLevel >= _staticDataService.NumberOfLevels;
      
      view.MissionName.text = _levelDataProvider.LevelConfig.Name;
      view.Score.text = _gameHUDService.CurrentScore.ToString();
      view.Exit.onClick.AddListener(OnExitClick);
      view.Next.onClick.AddListener(OnNextClick);
      view.Credits.onClick.AddListener(OnCreditsClick);
      
      view.Next.gameObject.SetActive(!lastLevel);
      view.Credits.gameObject.SetActive(lastLevel);
    }

    public void OnDetach(WinWindow view)
    {
      view.Next.onClick.RemoveAllListeners();
      view.Exit.onClick.RemoveAllListeners();
      view.Credits.onClick.RemoveAllListeners();
    }

    private void OnExitClick()
    {
      _windowService.Pop();
      _entityFactory.CreateEntity<GameEntity>()
        .AddRoute(RouteName.MainMenu);
    }

    private void OnNextClick()
    {
      _windowService.Pop();
      _entityFactory.CreateEntity<GameEntity>()
        .AddRoute(RouteName.NextLevel);
    }

    private void OnCreditsClick()
    {
      _windowService.Pop();
      _entityFactory.CreateEntity<GameEntity>()
        .AddRoute(RouteName.Credits);
    }
  }
}