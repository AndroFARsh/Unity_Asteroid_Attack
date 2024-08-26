using Code.Game.Level.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.Level
{
  public class LevelFeature : Feature
  {
    public LevelFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitLevelSystem>());
      Add(systems.Create<SpawnPlayerSystem>());
      Add(systems.Create<DetectWinSystem>());
    }
  }
}