using Code.Game.HostileSpawners.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.HostileSpawners
{
  public sealed class HostileSpawnerFeature : Feature
  {
    public HostileSpawnerFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeHostileSpawnerSystem>());
      Add(systems.Create<TickHostileSpawnerSystem>());
      Add(systems.Create<SpawnHostileWhenReadySystem>());
      Add(systems.Create<MoveToNextWaveSystem>());
    }
  }
}