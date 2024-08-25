using Entitas;

namespace Code.Game.Destroy.Systems
{
  public class EarnScoreSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _gameStateEntities;
    private readonly IGroup<GameEntity> _scoreEntities;

    public EarnScoreSystem(GameContext game)
    {
      _scoreEntities = game.GetGroup(GameMatcher.AllOf(GameMatcher.ReadyToCleanUp, GameMatcher.Score));
      _gameStateEntities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Level, GameMatcher.CurrentScore));
    }

    public void Execute()
    {
      foreach (GameEntity scoreEntity in _scoreEntities)
      foreach (GameEntity gameStateEntity in _gameStateEntities)
        gameStateEntity.ReplaceCurrentScore(gameStateEntity.CurrentScore + scoreEntity.Score);
    }
  }
}