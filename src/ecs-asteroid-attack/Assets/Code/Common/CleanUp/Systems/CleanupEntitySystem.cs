using System.Collections.Generic;
using Code.Infrastructure.EntityFactories;
using Entitas;

namespace Code.Common.CleanUp.Systems
{
  public class CleanupEntitySystem<TEntity> : ICleanupSystem 
    where TEntity : class, IEntity
  {
    private readonly IGroup<TEntity> _entities;
    private readonly List<TEntity> _buffer = new(128);

    public CleanupEntitySystem(IEntityFactory factory)
    {
      _entities = factory.BuildGroup<TEntity>().With<ReadyToCleanUpComponent>().Build();
    }

    public void Cleanup()
    {
      foreach (TEntity entity in _entities.GetEntities(_buffer))
        entity.Destroy();
    }
  }
}