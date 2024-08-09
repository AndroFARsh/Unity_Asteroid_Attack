using System.Collections.Generic;
using Entitas;

namespace Code.Game.View.Systems
{
  public class ApplyVelocitySystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public ApplyVelocitySystem(GameContext game)
    {
      _entities = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Rigidbody2D, 
          GameMatcher.Velocity));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        entity.Rigidbody2D.velocity = entity.Velocity;
      }
    }
  }
}