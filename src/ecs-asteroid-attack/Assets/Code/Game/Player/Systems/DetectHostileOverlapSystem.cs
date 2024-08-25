using System.Collections.Generic;
using Code.Game.Common.Extensions;
using Code.Infrastructure.Physics;
using Entitas;

namespace Code.Game.Player.Systems
{
  public class DetectHostileOverlapSystem : IExecuteSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _entities;

    public DetectHostileOverlapSystem(GameContext game, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _entities = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Player,
          GameMatcher.Collider2D));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      foreach (GameEntity otherEntity in OverlapHostileAll(entity))
      {
        entity.isReadyToCleanUp = true;
        otherEntity.isReadyToCleanUp = true;
      }
    }

    private IEnumerable<GameEntity> OverlapHostileAll(GameEntity entity) => 
      _physicsService.OverlapColliderAll<GameEntity>(entity.Collider2D, CollisionLayer.Hostiles.AsMask());
  }
}