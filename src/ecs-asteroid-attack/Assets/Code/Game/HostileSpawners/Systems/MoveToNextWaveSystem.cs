using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Game.HostileSpawners.Configs;
using Code.Levels.Services;
using Entitas;

namespace Code.Game.HostileSpawners.Systems
{
  public class MoveToNextWaveSystem : IExecuteSystem
  {
    private readonly ILevelDataProvider _levelDataProvider;
    
    private readonly IGroup<GameEntity> _hostileEntities;
    private readonly IGroup<GameEntity> _spawnerEntities;
    
    private readonly List<GameEntity> _buffer = new();

    public MoveToNextWaveSystem(GameContext game, ILevelDataProvider levelDataProvider)
    {
      _levelDataProvider = levelDataProvider;
      _hostileEntities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hostile));
      _spawnerEntities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.HostileSpawner,
          GameMatcher.HostileSpawnerWave,
          GameMatcher.HostileSpawnerReadyMoveToNextWave));
    }

    public void Execute()
    {
      if (_hostileEntities.IsNotEmpty()) return;
      
      foreach (GameEntity entity in _spawnerEntities.GetEntities(_buffer))
      {
        int nextWave = entity.HostileSpawnerWave + 1;
        if (nextWave < _levelDataProvider.LevelConfig.WavesSetup.Count)
        {
          HostileWaveSetup waveSetup = _levelDataProvider.LevelConfig.WavesSetup[nextWave];
          entity
            .ReplaceHostileSpawnerWave(nextWave)
            .ReplaceHostileSpawnedPerWave(0)
            .ReplaceCooldownTime(waveSetup.Cooldown)
            .ReplaceCooldownLeft(waveSetup.Cooldown)
            .With(e => e.isCooldownUp = false)
            .With(e => e.isHostileSpawnerReadyMoveToNextWave = false);
        }
        else
        {
          entity.isReadyToCleanUp = true;
        }
      }
    }
  }
}