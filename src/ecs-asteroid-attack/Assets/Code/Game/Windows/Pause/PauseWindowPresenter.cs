using Code.Game.HUD.Services;
using Code.Infrastructure.PersistentData;
using Code.Infrastructure.States;
using Code.Infrastructure.Time;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Code.Project.States;
using UnityEngine;

namespace Code.Game.Windows.Pause
{
  public class PauseWindowPresenter : IUIViewPresenter<PauseWindow>
  {
    private readonly IWindowService _windowService;
    private readonly IStateMachine _stateMachine;
    private readonly ITimeService _timeService;
    private readonly IGameHUDService _gameHUDService;
    private readonly IPersistentDataProvider _persistentDataProvider;

    public PauseWindowPresenter(
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
    
    public void OnAttach(PauseWindow view)
    {
      _timeService.Pause();
      
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
      _timeService.Resume();

      UpdateProgressData();
      
      _windowService.Pop();
      _stateMachine.Enter<LoadHomeState>();
    }
    
    private void OnResumeClick()
    {
      _timeService.Resume();
      _windowService.Pop();
    }

    private void OnSettingsClick() => _windowService.Push(WindowName.SettingsWindow);
    
    private void UpdateProgressData()
    {
      _persistentDataProvider.ProgressData.MaxScore =
        Mathf.Max(_persistentDataProvider.ProgressData.MaxScore, _gameHUDService.CurrentScore);
      _persistentDataProvider.ProgressData.PrevScore = _gameHUDService.CurrentScore;
      _persistentDataProvider.ProgressData.Score = 0;
    }
  }
}