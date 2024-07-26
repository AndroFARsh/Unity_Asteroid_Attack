using Code.Infrastructure.WindowManagement;
using Code.Infrastructure.WindowManagement.Configs;
using Code.Levels.Configs;

namespace Code.Infrastructure.StaticData
{
  public interface IStaticDataService
  {
    int NumberOfLevels { get; }
    
    void LoadAll();
    
    WindowConfig GetWindowConfig(WindowName name);
    
    LevelConfig GetLevelConfig(int index);
  }
}