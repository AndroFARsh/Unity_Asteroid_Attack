using Code.Game.Abilities.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.Abilities
{
  public sealed class AbilityFeature : Feature
  {
    public AbilityFeature(ISystemFactory systems)
    {
      Add(systems.Create<SpawnProjectileSystem>());
    }
  }
}