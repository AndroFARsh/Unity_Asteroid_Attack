using System.Collections.Generic;
using System.Linq;
using Code.Game.Hostiles.Factories;
using Code.Game.HostileSpawners.Configs;
using Code.Infrastructure.Randoms;
using Code.Levels.Services;
using Entitas;

namespace Code.Game.HostileSpawners.Systems
{
  public class SpawnHostileWhenReadySystem : IExecuteSystem 
  {
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IHostileFactory _hostileFactory;
    private readonly IRandomService _randomService;

    private readonly IGroup<GameEntity> _hostileEntities;
    private readonly IGroup<GameEntity> _spawnerEntities;
    
    private readonly List<GameEntity> _buffer = new(32);

    private SpawnHostileWhenReadySystem(
      GameContext game, 
      ILevelDataProvider levelDataProvider, 
      IHostileFactory hostileFactory,
      IRandomService randomService)
    {
      _levelDataProvider = levelDataProvider;
      _hostileFactory = hostileFactory;
      _randomService = randomService;
      _hostileEntities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hostile));
      _spawnerEntities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.HostileSpawner,
          GameMatcher.HostileSpawnerWave,
          GameMatcher.HostileSpawnedPerWave,
          GameMatcher.HostileSpawnedTotal,
          GameMatcher.CooldownUp));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _spawnerEntities.GetEntities(_buffer))
      {
        HostileWaveSetup waveSetup = _levelDataProvider.LevelConfig.WavesSetup[entity.HostileSpawnerWave];
        if (_hostileEntities.count >= waveSetup.MaxAlive || entity.HostileSpawnedPerWave >= waveSetup.Total) continue;

        foreach (HostileSetup hostile in waveSetup.Hostiles.Where(hostile => _randomService.Range(0, 1) <= hostile.Probability))
        {
          _hostileFactory.CreateHostile(hostile.Name);
          break;
        }

        entity.ReplaceHostileSpawnedPerWave(entity.HostileSpawnedPerWave+1);
        entity.ReplaceHostileSpawnedTotal(entity.HostileSpawnedTotal+1);
        entity.ReplaceCooldownLeft(waveSetup.Cooldown);
        entity.isCooldownUp = false;
        entity.isHostileSpawnerReadyMoveToNextWave = entity.HostileSpawnedPerWave >= waveSetup.Total;
      }
    }
  }
}