using Code.Common.Destroy;
using Code.Common.View;
using Code.Game.Cameras;
using Code.Game.HostileSpawners;
using Code.Game.Input;
using Code.Game.Player;
using Code.Game.View;
using Code.Infrastructure.Systems;

namespace Code.Game
{
  public sealed class GameplayFeature : Feature
  {
    public GameplayFeature(ISystemFactory systems)
    {
      Add(systems.Create<InputFeature>());
      Add(systems.Create<PlayerFeature>());
      Add(systems.Create<HostileSpawnerFeature>());
      Add(systems.Create<ViewFeature>());
      
      Add(systems.Create<CamerasFeature>());
      
      Add(systems.Create<GameplayViewFeature>());
      Add(systems.Create<DestroyFeature>());
    }
  }
}