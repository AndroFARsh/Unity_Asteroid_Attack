using System.Collections.Generic;
using Code.Infrastructure.Time;
using Entitas;

namespace Code.Game.HostileSpawners.Systems
{
  public class TickHostileSpawnerSystem : IExecuteSystem 
  {
    private readonly List<GameEntity> _buffers = new(1);
    
    private readonly IGroup<GameEntity> _entities;
    private readonly ITimeService _timeService;
    
    private TickHostileSpawnerSystem(GameContext game, ITimeService timeService)
    {
      _timeService = timeService;
      _entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.HostileSpawner,
          GameMatcher.HostileSpawnerTimer));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffers))
      {
        entity.ReplaceHostileSpawnerTimer(entity.HostileSpawnerTimer - _timeService.DeltaTime);
        if (entity.HostileSpawnerTimer <= 0)
        {
          entity.isHostileSpawnerReady = true;
          entity.RemoveHostileSpawnerTimer();
        }
      }
    }
  }
}