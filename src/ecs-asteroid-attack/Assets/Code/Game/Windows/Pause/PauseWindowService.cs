using Code.Common.View.UI;
using Code.Infrastructure.States;
using Code.Infrastructure.Time;
using Code.Infrastructure.Windows.Services;
using Code.Project.States;

namespace Code.Game.Windows.Pause
{
  public class PauseWindowService : IUIViewService<PauseWindow>
  {
    private readonly IWindowService _windowService;
    private readonly IStateMachine _stateMachine;
    private readonly ITimeService _timeService;
    
    public PauseWindowService(
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
      _timeService.StopTime();
      
      view.Resume.onClick.AddListener(OnResumeClick);
      view.Exit.onClick.AddListener(OnExitClick);
    }

    public void OnDetach(PauseWindow view)
    {
      view.Resume.onClick.RemoveListener(OnResumeClick);
      view.Exit.onClick.RemoveListener(OnExitClick);
      
      _timeService.StartTime();
    }
    
    private void OnExitClick()
    {
      _timeService.StartTime();
      
      _windowService.Pop();
      _stateMachine.Enter<LoadHomeState>();
    }
    
    private void OnResumeClick()
    {
      _windowService.Pop();
    }
  }
}