using Code.Game.View.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.View
{
  public sealed class GameplayViewFeature : Feature
  {
    public GameplayViewFeature(ISystemFactory systems)
    {
      Add(systems.Create<ApplyWorldPositionSystem>());
      Add(systems.Create<ApplyForceSystem>());
      Add(systems.Create<ApplyTorqueSystem>());
      Add(systems.Create<ApplyVelocitySystem>());
      Add(systems.Create<ApplyAngularVelocitySystem>());
    }
  }
}