using Code.Game.HUD.Services;
using Entitas;

namespace Code.Game.HUD.Systems
{
  public class UpdateHUDScoreSystem : IExecuteSystem
  {
    private readonly IGameHUDService _gameHUDService;
    private readonly IGroup<GameEntity> _entities;

    public UpdateHUDScoreSystem(GameContext game, IGameHUDService gameHUDService)
    {
      _gameHUDService = gameHUDService;
      _entities = game.GetGroup(
        GameMatcher.AllOf(GameMatcher.Level, GameMatcher.CurrentScore));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
        _gameHUDService.UpdateScore(entity.CurrentScore);
    }
  }
}