using Code.Infrastructure.States;
using Code.Infrastructure.Time;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Code.Project.States;

namespace Code.Game.Windows.Pause
{
  public class PauseWindowPresenter : IUIViewPresenter<PauseWindow>
  {
    private readonly IWindowService _windowService;
    private readonly IStateMachine _stateMachine;
    private readonly ITimeService _timeService;
    
    public PauseWindowPresenter(
      IWindowService windowService, 
      IStateMachine stateMachine,
      ITimeService timeService)
    {
      _windowService = windowService;
      _stateMachine = stateMachine;
      _timeService = timeService;
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
      
      _windowService.Pop();
      _stateMachine.Enter<LoadHomeState>();
    }
    
    private void OnResumeClick()
    {
      _timeService.Resume();
      _windowService.Pop();
    }

    private void OnSettingsClick() => _windowService.Push(WindowName.SettingsWindow);
  }
}