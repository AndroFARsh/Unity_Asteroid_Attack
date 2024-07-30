using Entitas;
using UnityEngine;

namespace Code.Game.View.Systems
{
  public class UpdateTransformRotationAlongDirectionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public UpdateTransformRotationAlongDirectionSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.RotateAlongDirection,
          GameMatcher.Rotating,
          GameMatcher.Transform, 
          GameMatcher.MoveDirection));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        float angle = Mathf.Atan2(-entity.MoveDirection.x, entity.MoveDirection.y) * Mathf.Rad2Deg;
        entity.Transform.rotation = Quaternion.Euler(0, 0, angle);
      }
    }
  }
}