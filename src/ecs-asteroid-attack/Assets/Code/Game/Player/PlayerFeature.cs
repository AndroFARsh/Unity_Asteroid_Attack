using Code.Game.Player.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.Player
{
  public class PlayerFeature : Feature
  {
    public PlayerFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializePlayerSpawnerSystem>());
      Add(systems.Create<SpawnPlayerSystem>());
      Add(systems.Create<RotationInputIntoPlayerRotationSystem>());
      Add(systems.Create<AccelerationInputIntoPlayerVelocitySystem>());
    }
  }
  
  
}