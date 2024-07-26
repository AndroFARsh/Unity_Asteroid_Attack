using System.Collections.Generic;
using Code.Common.View.Factories;
using Entitas;

namespace Code.Common.View.Systems
{
  public class CreateInputEntityViewFromPathSystem : IExecuteSystem
  {
    private readonly IEntityViewFactory _entityViewFactory;
    private readonly List<InputEntity> _buffer = new(32);
    
    private readonly IGroup<InputEntity> _entities;
    
    public CreateInputEntityViewFromPathSystem(InputContext input, IEntityViewFactory entityViewFactory)
    {
      _entityViewFactory = entityViewFactory;
      _entities = input.GetGroup(InputMatcher
        .AllOf(InputMatcher.ViewPath)
        .NoneOf(InputMatcher.View));
    }

    public void Execute()
    {
      foreach (InputEntity entity in _entities.GetEntities(_buffer))
        _entityViewFactory.CreateViewForEntityFromPath(entity);
    }
  }
}