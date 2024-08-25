using Code.Game.Destroy.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.Destroy
{
  public sealed class DestroyFeature : Feature
  {
    public DestroyFeature(ISystemFactory systems)
    {
      Add(systems.Create<SpawnExplosionEffectSystem>());
      Add(systems.Create<SpawnShardsSystem>());
      Add(systems.Create<EarnScoreSystem>());
    }
  }
}