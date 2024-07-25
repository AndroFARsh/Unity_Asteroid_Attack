using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Common.Destroy.Systems
{
  public class CleanupReadyToDestroyGameEntityViewSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(128);

    public CleanupReadyToDestroyGameEntityViewSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.ReadyToDestroy, GameMatcher.View));
    }

    public void Cleanup()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        entity.View.Release();
        Object.Destroy(entity.View.GameObject);
      }
    }
  }
}