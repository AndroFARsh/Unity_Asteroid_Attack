using Code.Infrastructure.Time;
using Entitas;

namespace Code.Common.Destroy.Systems
{
  public class SelfDestructedCountDownMetaEntitySystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<MetaEntity> _entities;

    public SelfDestructedCountDownMetaEntitySystem(MetaContext meta, ITimeService time)
    {
      _time = time;
      _entities = meta.GetGroup(MetaMatcher.SelfDestroyTimer);
    }

    public void Execute()
    {
      foreach (MetaEntity entity in _entities)
      {
        entity.ReplaceSelfDestroyTimer(entity.SelfDestroyTimer - _time.DeltaTime);
        if (entity.SelfDestroyTimer <= 0)
          entity.isReadyToDestroy = true;
      }
    }
  }
}