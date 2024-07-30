using Code.Infrastructure.Time;
using Entitas;

namespace Code.Game.View.Systems
{
  public class UpdateTransformRotateSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _entities;

    public UpdateTransformRotateSystem(GameContext game, ITimeService timeService)
    {
      _timeService = timeService;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Rotatable,
          GameMatcher.Rotating,
          GameMatcher.Transform, 
          GameMatcher.RotationSpeed,
          GameMatcher.RotateDirection));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
        entity.Transform.Rotate(0, 0, entity.RotationSpeed * entity.RotateDirection * _timeService.DeltaTime);
    }
  }
}