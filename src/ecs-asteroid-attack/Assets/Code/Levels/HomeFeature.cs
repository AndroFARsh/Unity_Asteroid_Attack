using Code.Common.CleanUp;
using Code.Game.Level.Systems;
using Code.Infrastructure.Systems;

namespace Code.Levels
{
  public sealed class LevelsFeature : Feature
  {
    public LevelsFeature(ISystemFactory systems)
    {
      Add(systems.Create<PlayBackgroundMusicSystem>());
      Add(systems.Create<CleanUpFeature>());
    }
  }
}