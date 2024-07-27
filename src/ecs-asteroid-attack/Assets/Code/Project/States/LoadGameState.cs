using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;
using Code.Levels.Configs;

namespace Code.Project.States
{
  public class LoadGameState : PayloadState<LevelConfig>
  {
    private readonly IStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadGameState(IStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    protected override async void OnEnter(LevelConfig config)
    {
      await _sceneLoader.LoadSceneAsync(config.SceneName);
      _stateMachine.Enter<GameState, LevelConfig>(config);
    }
  }
}