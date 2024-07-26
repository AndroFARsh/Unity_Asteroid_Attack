using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Common.Destroy.Systems
{
  public class CleanupReadyToDestroyInputEntityViewSystem : ICleanupSystem
  {
    private readonly IGroup<InputEntity> _entities;
    private readonly List<InputEntity> _buffer = new(128);

    public CleanupReadyToDestroyInputEntityViewSystem(InputContext input)
    {
      _entities = input.GetGroup(InputMatcher.AllOf(InputMatcher.ReadyToDestroy, InputMatcher.View));
    }

    public void Cleanup()
    {
      foreach (InputEntity entity in _entities.GetEntities(_buffer))
      {
        entity.View.Release();
        Object.Destroy(entity.View.GameObject);
      }
    }
  }
}