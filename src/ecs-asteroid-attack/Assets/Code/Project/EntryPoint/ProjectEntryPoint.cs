using Code.Infrastructure.States;
using Code.Project.States;
using VContainer.Unity;

namespace Code.Project.EntryPoint
{
  public class ProjectEntryPoint : IStartable
  {
    private readonly IStateMachine _stateMachine;

    public ProjectEntryPoint(IStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public void Start() => _stateMachine.Enter<BootstrapState>();
  }
}