using System.Collections.Generic;
using Code.Common.EntityFactories;
using Code.Common.Extensions;
using Code.Game.HostileSpawners.Configs;
using Code.Levels.Services;
using Entitas;

namespace Code.Game.HostileSpawners.Systems
{
  public partial class InitializeHostileSpawnerSystem : IInitializeSystem 
  {
    private readonly IEntityFactory _entityFactory;
    private readonly ILevelDataProvider _levelDataProvider;

    private InitializeHostileSpawnerSystem(IEntityFactory entityFactory, ILevelDataProvider levelDataProvider)
    {
      _entityFactory = entityFactory;
      _levelDataProvider = levelDataProvider;
    }

    public void Initialize()
    {
      List<HostileWaveSetup> waves = _levelDataProvider.LevelConfig.WavesSetup;
      HostileWaveSetup wave = waves[0];
      _entityFactory.Create<GameEntity>()
        .With(e => e.isHostileSpawner = true)
        .AddHostileSpawnerWave(0)
        .AddHostileSpawnerCooldown(wave.Cooldown)
        .AddHostileSpawnerTimer(wave.Cooldown)
        .AddHostileSpawnedPerWave(0)
        .AddHostileSpawnedTotal(0);
    }
  }
}