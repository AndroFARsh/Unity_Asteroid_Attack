using Code.Game.HUD.Services;
using Entitas;

namespace Code.Game.HUD.Systems
{
  public class UpdateHUDLivesSystem : IExecuteSystem
  {
    private readonly IGameHUDService _gameHUDService;
    private readonly IGroup<GameEntity> _entities;

    public UpdateHUDLivesSystem(GameContext game, IGameHUDService gameHUDService)
    {
      _gameHUDService = gameHUDService;
      _entities = game.GetGroup(
        GameMatcher.AllOf(GameMatcher.Level, GameMatcher.PlayerCurrentLive, GameMatcher.PlayerTotalLive));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
        _gameHUDService.UpdateLives(entity.PlayerCurrentLive, entity.PlayerTotalLive);
    }
  }
}