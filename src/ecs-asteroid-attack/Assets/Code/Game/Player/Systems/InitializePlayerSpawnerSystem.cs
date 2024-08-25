using Code.Common.Extensions;
using Code.Game.HUD.Services;
using Code.Infrastructure.EntityFactories;
using Entitas;

namespace Code.Game.Player.Systems
{
  public class InitializePlayerSpawnerSystem : IInitializeSystem 
  {
    private readonly IEntityFactory _entityFactory;
    private readonly IGameHUDService _gameHUDService;

    private InitializePlayerSpawnerSystem(IEntityFactory entityFactory, IGameHUDService gameHUDService)
    {
      _entityFactory = entityFactory;
      _gameHUDService = gameHUDService;
    }

    public void Initialize()
    {
      _gameHUDService.UpdateLives(3, 3);
      _entityFactory.CreateEntity<GameEntity>()
        .With(e => e.isPlayerSpawner = true)
        .AddPlayerCurrentLive(3)
        .AddPlayerTotalLive(3)
        ;
    }
  }
}