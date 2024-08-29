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
      Add(systems.Create<UnlockNextLevelSystem>());
      Add(systems.Create<PlayBackgroundMusicSystem>());

      Add(systems.Create<PauseGameSystem>());
      Add(systems.Create<ResumeGameSystem>());
      
      Add(systems.Create<NavigateSystem>());

      Add(systems.Create<UpdateProgressDataOnGameOverSystem>());
      Add(systems.Create<UpdateProgressDataOnWinSystem>());
      Add(systems.Create<ResetTimeServiceSystem>());
      Add(systems.Create<SaveProgressDataSystem>());
    }
  }
}