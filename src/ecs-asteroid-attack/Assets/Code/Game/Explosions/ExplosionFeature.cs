using Code.Game.Explosions.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.Explosions
{
  public sealed class ExplosionFeature : Feature
  {
    public ExplosionFeature(ISystemFactory systems)
    {
      Add(systems.Create<RunExplosionSystem>());    
    }
  }
}