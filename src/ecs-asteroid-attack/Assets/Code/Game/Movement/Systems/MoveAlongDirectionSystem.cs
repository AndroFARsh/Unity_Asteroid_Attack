using Code.Infrastructure.Time;
using Entitas;

namespace Code.Game.Movement.Systems
{
  public class MoveAlongDirectionSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _entities;

    public MoveAlongDirectionSystem(GameContext game, ITimeService timeService)
    {
      _timeService = timeService;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Movable,
          GameMatcher.Moving, 
          GameMatcher.MoveDirection, 
          GameMatcher.MoveVelocity, 
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        entity.ReplaceWorldPosition(entity.WorldPosition + _timeService.DeltaTime * entity.MoveVelocity * entity.MoveDirection);
      }
    }
  }
}