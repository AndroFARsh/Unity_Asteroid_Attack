using Code.Game.GameplayState.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.GameplayState
{
  public class GameStateFeature : Feature
  {
    public GameStateFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitGameStateSystem>());
      Add(systems.Create<SpawnPlayerSystem>());
    }
  }
}