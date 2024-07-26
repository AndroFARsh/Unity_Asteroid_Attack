using System.Collections.Generic;
using Code.Common.View.UI;
using Code.Infrastructure.StaticData;
using Code.Levels.UI.Factories;
using Code.Levels.UI.LevelsButton;
using UnityEngine;

namespace Code.Levels.UI.LevelsMenu
{
  public class LevelsMenuUIService : IUIViewService<LevelsMenuUIView>
  {
    private readonly IStaticDataService _staticDataService;
    private readonly ILevelButtonFactory _factory;
    private readonly List<LevelButtonUIView> _buttons = new ();
    
    public LevelsMenuUIService(IStaticDataService staticDataService, ILevelButtonFactory factory)
    {
      _staticDataService = staticDataService;
      _factory = factory;
    }
    
    public void OnAttach(LevelsMenuUIView view)
    {
      for (int level = 0; level < _staticDataService.NumberOfLevels; level++)
      {
        LevelButtonUIView button = _factory.CreateButton(view.Content);
        button.OnAttach(level);
        _buttons.Add(button);
      }
    }

    public void OnDetach(LevelsMenuUIView view)
    {
      foreach (LevelButtonUIView button in _buttons)
      {
        button.OnDetach();
        Object.Destroy(button); 
      }
      _buttons.Clear();
    }
  }
}