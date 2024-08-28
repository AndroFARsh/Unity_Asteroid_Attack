using Code.Game.HUD.Services;
using Code.Infrastructure.PersistentData;
using Code.Infrastructure.States;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.Time;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;
using Code.Levels.Configs;
using Code.Levels.Services;
using Code.Project.States;
using UnityEngine;

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
    private readonly IPersistentDataProvider _persistentDataProvider;

    public WinWindowPresenter(
      IWindowService windowService,
      IStateMachine stateMachine,
      ITimeService timeService,
      IGameHUDService gameHUDService,
      ILevelDataProvider levelDataProvider,
      IStaticDataService staticDataService,
      IPersistentDataProvider persistentDataProvider
    )
    {
      _windowService = windowService;
      _stateMachine = stateMachine;
      _timeService = timeService;
      _gameHUDService = gameHUDService;
      _levelDataProvider = levelDataProvider;
      _staticDataService = staticDataService;
      _persistentDataProvider = persistentDataProvider;
    }

    public void OnAttach(WinWindow view)
    {
      int nextLevel = _levelDataProvider.LevelConfig.Number + 1;
      bool lastLevel = nextLevel >= _staticDataService.NumberOfLevels;
      
      _timeService.Pause();

      view.MissionName.text = _levelDataProvider.LevelConfig.Name;
      view.Score.text = _gameHUDService.CurrentScore.ToString();
      view.Exit.onClick.AddListener(OnExitClick);
      view.Next.onClick.AddListener(OnNextClick);
      view.Credits.onClick.AddListener(OnCreditsClick);
      
      view.Next.gameObject.SetActive(!lastLevel);
      view.Credits.gameObject.SetActive(lastLevel);
      
      UpdateProgressData(nextLevel);
    }

    public void OnDetach(WinWindow view)
    {
      view.Next.onClick.RemoveListener(OnNextClick);
      view.Exit.onClick.RemoveListener(OnExitClick);

      _timeService.Resume();
    }

    private void OnExitClick()
    {
      ResetScore();

      _windowService.Pop();
      _stateMachine.Enter<LoadHomeState>();
    }

    private void ResetScore()
    {
      _persistentDataProvider.ProgressData.PrevScore = _persistentDataProvider.ProgressData.Score;
      _persistentDataProvider.ProgressData.Score = 0;
    }

    private void OnNextClick()
    {
      _windowService.Pop();
      
      int nextLevel = _levelDataProvider.LevelConfig.Number + 1;
      LevelConfig nextLevelConfig = _staticDataService.GetLevelConfig(nextLevel);

      _levelDataProvider.SetCurrentLevel(nextLevelConfig);
      _stateMachine.Enter<LoadGameState>();
    }

    private void UpdateProgressData(int nextLevel)
    {
      _persistentDataProvider.ProgressData.Score = _gameHUDService.CurrentScore;
      _persistentDataProvider.ProgressData.MaxScore =
        Mathf.Max(_persistentDataProvider.ProgressData.MaxScore, _gameHUDService.CurrentScore);
      _persistentDataProvider.ProgressData.LastUnlockedLevel =
        Mathf.Max(_persistentDataProvider.ProgressData.LastUnlockedLevel, nextLevel);
    }

    private void OnCreditsClick()
    {
      ResetScore();
      
      _windowService.Pop();
      _stateMachine.Enter<LoadCreditsState>();
    }
  }
}