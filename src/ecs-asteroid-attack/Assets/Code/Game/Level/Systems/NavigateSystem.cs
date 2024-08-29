using Code.Infrastructure.States;
using Code.Levels.Services;
using Code.Project.States;
using Entitas;

namespace Code.Game.Level.Systems
{
  public class NavigateSystem : IExecuteSystem
  {
    private readonly IStateMachine _stateMachine;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IGroup<GameEntity> _navigateEntities;
    private readonly IGroup<GameEntity> _levelEntities;
    
    public NavigateSystem(
      GameContext game, 
      IStateMachine stateMachine, 
      ILevelDataProvider levelDataProvider)
    {
      _stateMachine = stateMachine;
      _levelDataProvider = levelDataProvider;
      _navigateEntities = game.GetGroup(GameMatcher.Route);
      _levelEntities = game.GetGroup(GameMatcher.Level);
    }

    public void Execute()
    {
      foreach (GameEntity entity in _navigateEntities)
      {
        entity.isReadyToCleanUp = true;
        bool _ = entity.Route switch
        {
          RouteName.Pause => PauseGame(),
          RouteName.Resume => ResumeGame(),
          RouteName.MainMenu => NavigateToMainMenu(),
          RouteName.RestartLevel => RestartCurrentLevel(),
          RouteName.NextLevel => NavigateToNextLevel(),
          RouteName.Credits => NavigateToCredits(),
          _ => false
        };
      }
    }

    private bool NavigateToCredits()
    {
      foreach (GameEntity entity in _levelEntities)
        entity.isPause = false;
      
      _stateMachine.Enter<LoadCreditsState>();
      return true;
    }

    private bool NavigateToNextLevel()
    {
      foreach (GameEntity entity in _levelEntities)
      {
        entity.isPause = false;
        entity.isNextLevel = true;
      }
      
      _levelDataProvider.SetCurrentLevel(_levelDataProvider.LevelIndex+1);
      _stateMachine.Enter<LoadGameState>();
      return true;
    }

    private bool RestartCurrentLevel()
    {
      foreach (GameEntity entity in _levelEntities)
        entity.isPause = false;

      _stateMachine.Enter<LoadGameState>();
      return true;
    }

    private bool NavigateToMainMenu()
    {
      foreach (GameEntity entity in _levelEntities)
        entity.isPause = false;
      
      _stateMachine.Enter<LoadHomeState>();
      return true;
    }

    private bool PauseGame()
    {
      foreach (GameEntity entity in _levelEntities)
      {
        entity.isPause = true;
        entity.isPauseWindow = true;
      }

      return true;
    }
    
    private bool ResumeGame()
    {
      foreach (GameEntity entity in _levelEntities)
      {
        entity.isPause = false;
        entity.isPauseWindow = false;
      }

      return true;
    }
  }
}