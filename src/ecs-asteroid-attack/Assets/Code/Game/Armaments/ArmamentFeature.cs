using Code.Game.Armaments.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.Armaments
{
  public sealed class ArmamentFeature : Feature
  {
    public ArmamentFeature(ISystemFactory systems)
    {
      Add(systems.Create<DetectCollisionSystem>());
    }
  }
}