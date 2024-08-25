using Code.Common.CleanUp;
using Code.Common.View;
using Code.Game.Abilities;
using Code.Game.Armaments;
using Code.Game.Cameras;
using Code.Game.Cooldowns.Systems;
using Code.Game.Destroy;
using Code.Game.Explosions;
using Code.Game.GameplayState;
using Code.Game.GameState;
using Code.Game.HostileSpawners;
using Code.Game.HUD;
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
      Add(systems.Create<CooldownSystem>());
      Add(systems.Create<InputFeature>());
      Add(systems.Create<GameStateFeature>());
      Add(systems.Create<HUDFeature>());
      Add(systems.Create<PlayerFeature>());
      Add(systems.Create<HostileSpawnerFeature>());
      Add(systems.Create<AbilityFeature>());
      Add(systems.Create<ArmamentFeature>());
      Add(systems.Create<DestroyFeature>());
      Add(systems.Create<ExplosionFeature>());
      Add(systems.Create<ViewFeature>());
      Add(systems.Create<CamerasFeature>());
      Add(systems.Create<GameplayViewFeature>());
      Add(systems.Create<CleanUpFeature>());
    }
  }
}