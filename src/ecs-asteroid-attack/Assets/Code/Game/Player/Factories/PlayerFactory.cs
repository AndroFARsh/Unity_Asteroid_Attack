using Code.Common.EntityFactories;
using Code.Common.Extensions;
using Code.Game.Player.Configs;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Game.Player.Factories
{
  public class PlayerFactory : IPlayerFactory
  {
    private readonly IEntityFactory _entityFactory;
    private readonly IStaticDataService _staticDataService;

    public PlayerFactory(IEntityFactory entityFactory, IStaticDataService staticDataService)
    {
      _entityFactory = entityFactory;
      _staticDataService = staticDataService;
    }

    public GameEntity CreatePlayer(Vector3 at)
    {
      PlayerConfig config = _staticDataService.GetPlayerConfig();
      return _entityFactory.Create<GameEntity>()
        .With(e => e.isPlayer = true)
        .With(e => e.isRotatable = true)
        .AddRotationSpeed(config.RotateSpeed)
        .With(e => e.isMovable = true)
        .AddMoveDirection(config.InitialMoveDirection)
        .AddMoveVelocity(0)
        .AddMoveAcceleration(config.MoveAcceleration)
        .AddMaxMoveSpeed(config.MaxMoveSpeed)
        .AddWorldPosition(at)
        .AddViewPrefab(config.ViewPrefab);
    }
  }
}