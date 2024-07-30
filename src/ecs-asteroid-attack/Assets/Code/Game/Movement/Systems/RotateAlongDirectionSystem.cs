using Code.Infrastructure.Time;
using Entitas;
using UnityEngine;

namespace Code.Game.Movement.Systems
{
  public class RotateAlongDirectionSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _entities;

    public RotateAlongDirectionSystem(GameContext game, ITimeService timeService)
    {
      _timeService = timeService;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.RotateAlongDirection,
          GameMatcher.Rotating,
          GameMatcher.MoveDirection,
          GameMatcher.RotateDirection));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        Vector2 forward = entity.MoveDirection;
        
        float angle = -entity.RotateDirection * entity.RotationSpeed * Mathf.Deg2Rad;
        float sin = Mathf.Sin(angle);
        float cos = Mathf.Cos(angle);
        
        Vector2 newForward = new(forward.x * cos - forward.y * sin, forward.x * sin + forward.y * cos);
        
        entity.ReplaceMoveDirection(Vector2.Lerp(forward, newForward, _timeService.DeltaTime).normalized);
      }
    }
  }
}