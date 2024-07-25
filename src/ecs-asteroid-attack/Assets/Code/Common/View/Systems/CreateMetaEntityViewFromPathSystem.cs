using System.Collections.Generic;
using Code.Common.View.Factories;
using Entitas;

namespace Code.Common.View.Systems
{
  public class CreateMetaEntityViewFromPathSystem : IExecuteSystem
  {
    private readonly IEntityViewFactory _entityViewFactory;
    private readonly List<MetaEntity> _buffer = new(32);
    
    private readonly IGroup<MetaEntity> _entities;
    
    public CreateMetaEntityViewFromPathSystem(MetaContext meta, IEntityViewFactory entityViewFactory)
    {
      _entityViewFactory = entityViewFactory;
      _entities = meta.GetGroup(MetaMatcher
        .AllOf(MetaMatcher.ViewPath)
        .NoneOf(MetaMatcher.View));
    }

    public void Execute()
    {
      foreach (MetaEntity entity in _entities.GetEntities(_buffer))
        _entityViewFactory.CreateViewForEntityFromPath(entity);
    }
  }
}