using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;

namespace Code.Project.States
{
  public class LoadLevelsState : NoPayloadState
  {
    private const string LevelsScreenSceneName = "Levels";
    
    private readonly IStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadLevelsState(IStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    protected override async void OnEnter()
    {
      await _sceneLoader.LoadSceneAsync(LevelsScreenSceneName);
      _stateMachine.Enter<HomeState>();
    }
  }
}