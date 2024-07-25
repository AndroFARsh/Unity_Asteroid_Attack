using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;

namespace Code.Project.States
{
  public class LoadHomeState : NoPayloadState
  {
    private const string HomeScreenSceneName = "Home";
    
    private readonly IStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadHomeState(IStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    protected override async void OnEnter()
    {
      await _sceneLoader.LoadSceneAsync(HomeScreenSceneName);
      _stateMachine.Enter<HomeState>();
    }
  }
}