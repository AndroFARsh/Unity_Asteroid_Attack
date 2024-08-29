using System.Collections.Generic;
using Code.Infrastructure.States;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.UI;
using Code.Levels.UI.Factories;
using Code.Levels.UI.LevelsButton;
using Code.Project.States;
using UnityEngine;

namespace Code.Levels.UI.LevelsMenu
{
  public class LevelsMenuUIPresenter : IUIViewPresenter<LevelsMenuUIView>
  {
    private readonly IStaticDataService _staticDataService;
    private readonly ILevelButtonFactory _factory;
    private readonly IStateMachine _stateMachine;
    
    private readonly List<LevelButtonUIView> _buttons = new ();
    
    public LevelsMenuUIPresenter(
      IStaticDataService staticDataService, 
      ILevelButtonFactory factory, 
      IStateMachine stateMachine)
    {
      _staticDataService = staticDataService;
      _factory = factory;
      _stateMachine = stateMachine;
    }
    
    public void OnAttach(LevelsMenuUIView view)
    {
      view.Back.onClick.AddListener(OnBackClicked);
      for (int level = 0; level < _staticDataService.NumberOfLevels; level++)
      {
        LevelButtonUIView button = _factory.CreateButton(view.Content);
        button.OnAttach(level);
        _buttons.Add(button);
      }
    }

    public void OnDetach(LevelsMenuUIView view)
    {
      view.Back.onClick.RemoveListener(OnBackClicked);
      foreach (LevelButtonUIView button in _buttons)
      {
        button.OnDetach();
        Object.Destroy(button); 
      }
      _buttons.Clear();
    }
    
    private void OnBackClicked() => _stateMachine.Enter<LoadHomeState>();
  }
}