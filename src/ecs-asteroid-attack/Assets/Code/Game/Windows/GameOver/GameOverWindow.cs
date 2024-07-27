using Code.Infrastructure.States;
using Code.Infrastructure.Time;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Code.Project.States;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Gameplay.HUD.Windows
{
  public class GameOverWindow : BaseWindow
  {
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private IWindowService _windowService;
    private IStateMachine _stateMachine;
    private ITimeService _timeService;
    
    [Inject]
    public void Construct(
      IWindowService windowService, 
      IStateMachine stateMachine,
      ITimeService timeService)
    {
      _windowService = windowService;
      _stateMachine = stateMachine;
      _timeService = timeService;
    }
    
    protected override void OnResume()
    {
      _timeService.StopTime();
      
      _restartButton.onClick.AddListener(OnRestartClick);
      _exitButton.onClick.AddListener(OnExitClick);
    }

    protected override void OnPause()
    {
      _restartButton.onClick.RemoveListener(OnRestartClick);
      _exitButton.onClick.RemoveListener(OnExitClick);
      
      _timeService.StartTime();
    }
    
    private void OnExitClick()
    {
      _timeService.StartTime();
      
      _windowService.Pop();
      _stateMachine.Enter<LoadHomeState>();
    }
    
    private void OnRestartClick()
    {
      _timeService.StartTime();
      
      _windowService.Pop();
      //_stateMachine.Enter<GameState>();
    }
  }
}