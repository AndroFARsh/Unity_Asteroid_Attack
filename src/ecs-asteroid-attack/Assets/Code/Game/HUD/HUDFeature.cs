using Code.Game.HUD.Systems;
using Code.Infrastructure.Systems;

namespace Code.Game.HUD
{
  public class HUDFeature : Feature
  {
    public HUDFeature(ISystemFactory systems)
    {
      Add(systems.Create<UpdateHUDLivesSystem>());
      Add(systems.Create<UpdateHUDScoreSystem>());
      Add(systems.Create<ShowGameOverWindowSystem>());
      Add(systems.Create<ShowWinWindowSystem>());
    }
  }
}