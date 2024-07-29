using Code.Infrastructure.SceneManagement;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Infrastructure;
using Code.Levels.Configs;
using Code.Levels.Services;

namespace Code.Project.States
{
  public class LoadGameState : PayloadState<LevelConfig>
  {
    private readonly IStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;
    private readonly ILevelDataProvider _levelDataProvider;

    public LoadGameState(IStateMachine stateMachine, ISceneLoader sceneLoader, ILevelDataProvider levelDataProvider)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _levelDataProvider = levelDataProvider;
    }

    protected override async void OnEnter(LevelConfig config)
    {
      await _sceneLoader.LoadSceneAsync(config.SceneName);
      _levelDataProvider.SetCurrentLevel(config);
      _stateMachine.Enter<GameState>();
    }
  }
}