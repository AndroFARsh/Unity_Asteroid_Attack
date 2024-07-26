using Code.Infrastructure.Time;
using Entitas;

namespace Code.Common.Destroy.Systems
{
  public class SelfDestructedCountDownInputEntitySystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<InputEntity> _entities;

    public SelfDestructedCountDownInputEntitySystem(InputContext input, ITimeService time)
    {
      _time = time;
      _entities = input.GetGroup(InputMatcher.SelfDestroyTimer);
    }

    public void Execute()
    {
      foreach (InputEntity entity in _entities)
      {
        entity.ReplaceSelfDestroyTimer(entity.SelfDestroyTimer - _time.DeltaTime);
        if (entity.SelfDestroyTimer <= 0)
          entity.isReadyToDestroy = true;
      }
    }
  }
}