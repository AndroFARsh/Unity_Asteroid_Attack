using Code.Game.View.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.View
{
  public sealed class GameplayViewFeature : Feature
  {
    public GameplayViewFeature(ISystemFactory systems)
    {
      Add(systems.Create<UpdateTransformRotateSystem>());
      Add(systems.Create<UpdateTransformRotationAlongDirectionSystem>());
      Add(systems.Create<UpdateTransformPositionSystem>());
    }
  }
}