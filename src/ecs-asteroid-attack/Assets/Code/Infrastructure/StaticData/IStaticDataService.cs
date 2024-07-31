using Code.Game.Hostiles;
using Code.Game.Hostiles.Configs;
using Code.Game.Player.Configs;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Configs;
using Code.Levels.Configs;

namespace Code.Infrastructure.StaticData
{
  public interface IStaticDataService
  {
    int NumberOfLevels { get; }
    
    void LoadAll();
    
    WindowConfig GetWindowConfig(WindowName name);
    
    LevelConfig GetLevelConfig(int index);
    
    PlayerConfig GetPlayerConfig();
    
    HostileConfig GetHostileName(HostileName name);
  }
}