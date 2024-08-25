using Code.Game.GameState.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.GameState
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