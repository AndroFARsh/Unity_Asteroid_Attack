using Code.Common.Curtains;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.StaticData;

namespace Code.Project.States
{
  public class BootstrapState : NoPayloadState
  {
    private readonly IStateMachine _stateMachine;
    private readonly ICurtainService _curtainService;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(IStateMachine stateMachine, ICurtainService curtainService, IStaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _curtainService = curtainService;
      _staticDataService = staticDataService;
    }

    protected override async void OnEnter()
    {
      await _curtainService.Show();
      _staticDataService.LoadAll();
      _stateMachine.Enter<LoadHomeState>();
    }
  }
}