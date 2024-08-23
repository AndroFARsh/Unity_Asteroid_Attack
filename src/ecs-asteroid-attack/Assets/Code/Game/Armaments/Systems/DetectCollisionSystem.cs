using System.Collections.Generic;
using Code.Game.Explosions.Factories;
using Code.Infrastructure.Physics;
using Entitas;

namespace Code.Game.Armaments.Systems
{
  public class DetectCollisionSystem : IExecuteSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _entities;

    public DetectCollisionSystem(GameContext game, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _entities = game.GetGroup(GameMatcher.AllOf(
        GameMatcher.ContactRadius,
        GameMatcher.PierceNumber,
        GameMatcher.LayerMask,
        GameMatcher.Rigidbody2D));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      foreach (GameEntity otherEntity in FindOverlaps(entity))
      {
        if (entity.PierceNumber > 0)
        {
          otherEntity.isReadyToDestroy = true;
          entity.ReplacePierceNumber(entity.PierceNumber - 1);
        }

        entity.isReadyToDestroy = entity.PierceNumber <= 0;
      }
    }

    private IEnumerable<GameEntity> FindOverlaps(GameEntity entity) =>
      _physicsService.OverlapCircleAll<GameEntity>(
        entity.Rigidbody2D.position,
        entity.ContactRadius,
        entity.LayerMask);
  }
}