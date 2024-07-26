using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Infrastructure.WindowManagement;
using Code.Infrastructure.WindowManagement.Configs;
using UnityEngine;

namespace Code.Infrastructure.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private readonly Dictionary<WindowName, WindowConfig> _windows = new();

    public void LoadAll()
    {
      LoadAllWindowConfig();
    }
    
    public WindowConfig GetWindowConfig(WindowName name) => _windows[name];

    private void LoadAllWindowConfig() => _windows.AddRange(Resources.LoadAll<WindowConfig>("Configs/Windows")
      .ToDictionary(c => c.Name, c => c));
  }
}