using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;

namespace Code.Project.States
{
  public class LoadCreditsState : NoPayloadState
  {
    private const string CreditsScreenSceneName = "Credits";
    
    private readonly IStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadCreditsState(IStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    protected override async void OnEnter()
    { 
      await _sceneLoader.LoadSceneAsync(CreditsScreenSceneName);
      _stateMachine.Enter<CreditsState>();
    }
  }
}