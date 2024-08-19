using System.Collections.Generic;
using Entitas;

namespace Code.Game.Explosions.Systems
{
  public class RunExplosionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(16);

    public RunExplosionSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.Explosion, GameMatcher.ExplosionAnimator)
        .NoneOf(GameMatcher.ExplosionRun));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        entity.ExplosionAnimator.Run();
        entity.isExplosionRun = true;
      }
    }
  }
}