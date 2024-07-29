using Code.Game.Cameras.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.Cameras
{
  public sealed class CamerasFeature : Feature
  {
    public CamerasFeature(ISystemFactory systems)
    {
      Add(systems.Create<TeleportObjectOnExitOfScreenBoundsSystem>());
    }
  }
}