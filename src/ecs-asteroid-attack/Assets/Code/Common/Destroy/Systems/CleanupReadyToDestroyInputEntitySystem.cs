using System.Collections.Generic;
using Entitas;

namespace Code.Common.Destroy.Systems
{
  public class CleanupReadyToDestroyInputEntitySystem : ICleanupSystem
  {
    private readonly IGroup<InputEntity> _entities;
    private readonly List<InputEntity> _buffer = new(128);

    public CleanupReadyToDestroyInputEntitySystem(InputContext input)
    {
      _entities = input.GetGroup(InputMatcher.ReadyToDestroy);
    }

    public void Cleanup()
    {
      foreach (InputEntity entity in _entities.GetEntities(_buffer))
        entity.Destroy();
    }
  }
}