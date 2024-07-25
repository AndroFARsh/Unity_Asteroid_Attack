using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.StaticData;

namespace Code.Project.States
{
  public class BootstrapState : NoPayloadState
  {
    private readonly IStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(IStateMachine stateMachine, IStaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
    }

    protected override void OnEnter()
    {
      _staticDataService.LoadAll();
      _stateMachine.Enter<LoadHomeState>();
    }
  }
}