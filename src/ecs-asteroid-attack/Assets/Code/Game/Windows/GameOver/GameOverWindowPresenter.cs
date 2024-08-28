using Code.Game.HUD.Services;
using Code.Infrastructure.PersistentData;
using Code.Infrastructure.States;
using Code.Infrastructure.Time;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows.Services;
using Code.Project.States;
using UnityEngine;

namespace Code.Game.Windows.GameOver
{
  public class GameOverWindowPresenter : IUIViewPresenter<GameOverWindow>
  {
    private readonly IWindowService _windowService;
    private readonly IStateMachine _stateMachine;
    private readonly ITimeService _timeService;
    private readonly IGameHUDService _gameHUDService;
    private readonly IPersistentDataProvider _persistentDataProvider;

    public GameOverWindowPresenter(
      IWindowService windowService, 
      IStateMachine stateMachine,
      ITimeService timeService,
      IGameHUDService gameHUDService,
      IPersistentDataProvider persistentDataProvider)
    {
      _windowService = windowService;
      _stateMachine = stateMachine;
      _timeService = timeService;
      _gameHUDService = gameHUDService;
      _persistentDataProvider = persistentDataProvider;
    }
    
    public void OnAttach(GameOverWindow view)
    {
      _timeService.Pause();

      view.Score.text = _gameHUDService.CurrentScore.ToString();
      view.Restart.onClick.AddListener(OnRestartClick);
      view.Exit.onClick.AddListener(OnExitClick);

      UpdateProgressData();
    }

    public void OnDetach(GameOverWindow view)
    {
      view.Restart.onClick.RemoveListener(OnRestartClick);
      view.Exit.onClick.RemoveListener(OnExitClick);
      
      _timeService.Resume();
    }
    
    private void OnExitClick()
    {
      _windowService.Pop();
      _stateMachine.Enter<LoadHomeState>();
    }
    
    private void OnRestartClick()
    {
      _windowService.Pop();
      _stateMachine.Enter<GameState>();
    }
    
    private void UpdateProgressData()
    {
      _persistentDataProvider.ProgressData.MaxScore =
        Mathf.Max(_persistentDataProvider.ProgressData.MaxScore, _gameHUDService.CurrentScore);
      _persistentDataProvider.ProgressData.PrevScore = _gameHUDService.CurrentScore;
      _persistentDataProvider.ProgressData.Score = 0;
    }
  }
}