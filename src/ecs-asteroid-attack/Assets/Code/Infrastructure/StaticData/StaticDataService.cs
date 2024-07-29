using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Game.Player.Configs;
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
    private PlayerConfig _playerConfig = null;

    public int NumberOfLevels => _levels.Count;
    
    public void LoadAll()
    {
      LoadAllWindowConfig();
      LoadAllLevelConfig();
      LoadPlayerConfig();
    }

    private void LoadPlayerConfig()
    {
      PlayerConfig[] configs = Resources.LoadAll<PlayerConfig>("Configs/Players");
      if (configs.IsNullOrEmpty() || configs.Length > 1)
        throw new Exception($"You should have only one player config. not {configs?.Length}");

      _playerConfig = configs[0];
    }

    public LevelConfig GetLevelConfig(int index) => _levels[index];
    public PlayerConfig GetPlayerConfig() => _playerConfig;

    public WindowConfig GetWindowConfig(WindowName name) => _windows[name];

    private void LoadAllWindowConfig() => _windows.AddRange(Resources.LoadAll<WindowConfig>("Configs/Windows")
      .ToDictionary(c => c.Name, c => c));

    private void LoadAllLevelConfig() =>
      _levels.AddRange(Resources.LoadAll<LevelConfig>("Configs/Levels").OrderBy(c => c.Number));
  }
}