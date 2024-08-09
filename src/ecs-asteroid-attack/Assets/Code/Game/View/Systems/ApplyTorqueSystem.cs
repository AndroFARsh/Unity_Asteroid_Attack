using System.Collections.Generic;
using Entitas;

namespace Code.Game.View.Systems
{
  public class ApplyTorqueSystem : IExecuteSystem
  {
    private readonly List<GameEntity> _buffer = new();
    private readonly IGroup<GameEntity> _entities;

    public ApplyTorqueSystem(GameContext game)
    {
      _entities = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Rigidbody2D, 
          GameMatcher.Torque));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        entity.Rigidbody2D.AddTorque(entity.Torque);
        entity.RemoveTorque();
      }
    }
  }
}