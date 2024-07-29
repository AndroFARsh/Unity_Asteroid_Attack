using Code.Common.EntityFactories;
using Code.Common.Extensions;
using UnityEngine;

namespace Code.Game.Player.Factories
{
  public class PlayerFactory : IPlayerFactory
  {
    private const string PlayerPrefabPath = "Game/Ship/SpaceShip";
    
    private readonly IEntityFactory _entityFactory;

    public PlayerFactory(IEntityFactory entityFactory)
    {
      _entityFactory = entityFactory;
    }
    
    public GameEntity CreatePlayer(Vector3 at) =>
      _entityFactory.Create<GameEntity>()
        .With(e => e.isPlayer = true)
        .With(e => e.isRotatable = true)
        .AddRotationSpeed(60)
        .With(e => e.isMovable = true)
        .AddMoveDirection(Vector2.up)
        .AddMoveVelocity(0)
        .AddMoveAcceleration(1)
        .AddMaxMoveSpeed(2)
        .AddWorldPosition(at)
        .AddViewPath(PlayerPrefabPath);
  }
}