using System.Collections.Generic;
using Entitas;

namespace Code.Common.Destroy.Systems
{
  public class CleanupReadyToDestroyMetaEntitySystem : ICleanupSystem
  {
    private readonly IGroup<MetaEntity> _entities;
    private readonly List<MetaEntity> _buffer = new(128);


    public CleanupReadyToDestroyMetaEntitySystem(MetaContext meta)
    {
      _entities = meta.GetGroup(MetaMatcher.ReadyToDestroy);
    }

    public void Cleanup()
    {
      foreach (MetaEntity entity in _entities.GetEntities(_buffer))
        entity.Destroy();
    }
  }
}