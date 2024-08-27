using Code.Common.CleanUp;
using Code.Home.Systems;
using Code.Infrastructure.Systems;

namespace Code.Levels
{
  public sealed class LevelsFeature : Feature
  {
    public LevelsFeature(ISystemFactory systems)
    {
      Add(systems.Create<PlayMenuBackgroundMusicSystem>());
      Add(systems.Create<CleanUpFeature>());
    }
  }
}