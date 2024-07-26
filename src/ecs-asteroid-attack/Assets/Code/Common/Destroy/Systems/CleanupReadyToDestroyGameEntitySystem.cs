using System.Collections.Generic;
using Entitas;

namespace Code.Common.Destroy.Systems
{
  public class CleanupReadyToDestroyGameEntitySystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(128);

    public CleanupReadyToDestroyGameEntitySystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher.ReadyToDestroy);
    }

    public void Cleanup()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
        entity.Destroy();
    }
  }
}