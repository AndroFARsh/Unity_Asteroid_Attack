using System.Collections.Generic;
using Code.Infrastructure.EntityFactories;
using Entitas;
using UnityEngine;

namespace Code.Common.CleanUp.Systems
{
  public class CleanupEntityViewSystem<TEntity> : ICleanupSystem
    where TEntity : class, IEntity
  {
    private readonly IGroup<TEntity> _entities;
    private readonly List<TEntity> _buffer = new(128);

    public CleanupEntityViewSystem(IEntityFactory factory)
    {
      _entities = factory.BuildGroup<TEntity>()
          .With<ReadyToCleanUpComponent>()
          .With<ViewComponent>()
          .Build();
    }

    public void Cleanup()
    {
      foreach (TEntity entity in _entities.GetEntities(_buffer))
      {
        if (entity.TryGetComponent(out ViewComponent view))
        {
          view.Value.Release();
          // TODO: return to pool
          Object.Destroy(view.Value.GameObject);
        }
      }
    }
  }
}