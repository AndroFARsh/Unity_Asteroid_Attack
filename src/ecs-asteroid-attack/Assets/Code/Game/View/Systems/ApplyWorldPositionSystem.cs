using System.Collections.Generic;
using Entitas;

namespace Code.Game.View.Systems
{
  public class ApplyWorldPositionSystem : IExecuteSystem
  {
    private readonly List<GameEntity> _buffer = new();
    private readonly IGroup<GameEntity> _entities;

    public ApplyWorldPositionSystem(GameContext game)
    {
      _entities = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Rigidbody2D, 
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        entity.Rigidbody2D.position = entity.WorldPosition;
        entity.RemoveWorldPosition();
      }
    }
  }
}