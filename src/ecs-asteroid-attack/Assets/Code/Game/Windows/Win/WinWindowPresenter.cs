using Code.Game.HUD.Services;
using Code.Infrastructure.States;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.Time;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;
using Code.Levels.Configs;
using Code.Levels.Services;
using Code.Project.States;

namespace Code.Game.Windows.Win
{
  public class WinWindowPresenter : IUIViewPresenter<WinWindow>
  {
    private readonly IWindowService _windowService;
    private readonly IStateMachine _stateMachine;
    private readonly ITimeService _timeService;
    private readonly IGameHUDService _gameHUDService;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IStaticDataService _staticDataService;

    public WinWindowPresenter(
      IWindowService windowService,
      IStateMachine stateMachine,
      ITimeService timeService,
      IGameHUDService gameHUDService,
      ILevelDataProvider levelDataProvider,
      IStaticDataService staticDataService
    )
    {
      _windowService = windowService;
      _stateMachine = stateMachine;
      _timeService = timeService;
      _gameHUDService = gameHUDService;
      _levelDataProvider = levelDataProvider;
      _staticDataService = staticDataService;
    }

    public void OnAttach(WinWindow view)
    {
      _timeService.Pause();

      view.MissionName.text = _levelDataProvider.LevelConfig.Name;
      view.Score.text = _gameHUDService.CurrentScore.ToString();
      view.Exit.onClick.AddListener(OnExitClick);
      view.Next.onClick.AddListener(OnNextClick);
      if (_levelDataProvider.LevelConfig.Number + 1 >= _staticDataService.NumberOfLevels)
      {
        // todo: add cred screen
        view.Next.interactable = false;
      }
    }

    public void OnDetach(WinWindow view)
    {
      view.Next.onClick.RemoveListener(OnNextClick);
      view.Exit.onClick.RemoveListener(OnExitClick);

      _timeService.Resume();
    }

    private void OnExitClick()
    {
      _windowService.Pop();
      _stateMachine.Enter<LoadHomeState>();
    }

    private void OnNextClick()
    {
      _windowService.Pop();
      _stateMachine.Enter<LoadGameState, LevelConfig>(
        _staticDataService.GetLevelConfig(_levelDataProvider.LevelConfig.Number + 1)
      );
    }
  }
}