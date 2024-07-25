using System.Collections.Generic;
using Code.Common.View.Factories;
using Entitas;

namespace Code.Common.View.Systems
{
  public class CreateGameEntityViewFromPathSystem : IExecuteSystem
  {
    private readonly IEntityViewFactory _entityViewFactory;
    private readonly List<GameEntity> _buffer = new(32);
    
    private readonly IGroup<GameEntity> _entities;
    
    public CreateGameEntityViewFromPathSystem(GameContext game, IEntityViewFactory entityViewFactory)
    {
      _entityViewFactory = entityViewFactory;
      _entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.ViewPath)
        .NoneOf(GameMatcher.View));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
        _entityViewFactory.CreateViewForEntityFromPath(entity);
    }
  }
}