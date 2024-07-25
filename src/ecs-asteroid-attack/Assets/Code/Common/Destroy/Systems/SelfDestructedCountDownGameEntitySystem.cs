using Code.Infrastructure.Time;
using Entitas;

namespace Code.Common.Destroy.Systems
{
  public class SelfDestructedCountDownGameEntitySystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _entities;

    public SelfDestructedCountDownGameEntitySystem(GameContext game, ITimeService time)
    {
      _time = time;
      _entities = game.GetGroup(GameMatcher.SelfDestroyTimer);
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        entity.ReplaceSelfDestroyTimer(entity.SelfDestroyTimer - _time.DeltaTime);
        if (entity.SelfDestroyTimer <= 0)
          entity.isReadyToDestroy = true;
      }
    }
  }
}