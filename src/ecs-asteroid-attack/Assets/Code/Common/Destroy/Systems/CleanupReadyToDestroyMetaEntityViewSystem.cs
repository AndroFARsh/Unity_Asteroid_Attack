using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Common.Destroy.Systems
{
  public class CleanupReadyToDestroyMetaEntityViewSystem : ICleanupSystem
  {
    private readonly IGroup<MetaEntity> _entities;
    private readonly List<MetaEntity> _buffer = new(128);

    public CleanupReadyToDestroyMetaEntityViewSystem(MetaContext meta)
    {
      _entities = meta.GetGroup(MetaMatcher.AllOf(MetaMatcher.ReadyToDestroy, MetaMatcher.View));
    }

    public void Cleanup()
    {
      foreach (MetaEntity entity in _entities.GetEntities(_buffer))
      {
        entity.View.Release();
        Object.Destroy(entity.View.GameObject);
      }
    }
  }
}