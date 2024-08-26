using Code.Common.CleanUp;
using Code.Home.Systems;
using Code.Infrastructure.Systems;

namespace Code.Home
{
  public sealed class HomeFeature : Feature
  {
    public HomeFeature(ISystemFactory systems)
    {
      Add(systems.Create<PlayBackgroundMusicSystem>());
      Add(systems.Create<CleanUpFeature>());
    }
  }
}