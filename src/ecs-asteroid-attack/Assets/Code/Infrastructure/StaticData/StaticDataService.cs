using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Configs;
using Code.Levels.Configs;
using UnityEngine;

namespace Code.Infrastructure.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private readonly Dictionary<WindowName, WindowConfig> _windows = new();
    private readonly List<LevelConfig> _levels = new();

    public int NumberOfLevels => _levels.Count;
    
    public void LoadAll()
    {
      LoadAllWindowConfig();
      LoadAllLevelConfig();
    }

    public LevelConfig GetLevelConfig(int index) => _levels[index];
    
    public WindowConfig GetWindowConfig(WindowName name) => _windows[name];

    private void LoadAllWindowConfig() => _windows.AddRange(Resources.LoadAll<WindowConfig>("Configs/Windows")
      .ToDictionary(c => c.Name, c => c));

    private void LoadAllLevelConfig() =>
      _levels.AddRange(Resources.LoadAll<LevelConfig>("Configs/Levels").OrderBy(c => c.Number));
  }
}