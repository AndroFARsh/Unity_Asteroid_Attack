using Code.Common.View.UI;
using Code.Infrastructure.PersistentData;
using Code.Infrastructure.States;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.UI;
using Code.Levels.Configs;
using Code.Levels.Services;
using Code.Project.States;
using UnityEngine;

namespace Code.Levels.UI.LevelsButton
{
  public class LevelButtonUIPresenter : IUIViewPresenter<LevelButtonUIView>
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IPersistentDataProvider _persistentDataProvider;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IStateMachine _stateMachine;

    public LevelButtonUIPresenter(
      IStaticDataService staticDataService, 
      IPersistentDataProvider persistentDataProvider, 
      ILevelDataProvider levelDataProvider,
      IStateMachine stateMachine)
    {
      _staticDataService = staticDataService;
      _persistentDataProvider = persistentDataProvider;
      _levelDataProvider = levelDataProvider;
      _stateMachine = stateMachine;
    }
    
    public void OnAttach(LevelButtonUIView view)
    {
      LevelConfig levelConfig = _staticDataService.GetLevelConfig(view.Level);
      view.Title.text = levelConfig.Name;
      view.Subtitle.text = $"Level {levelConfig.Number+1}";
      view.Button.onClick.AddListener(() => { OnLevelButtonClick(levelConfig); });

      view.Button.interactable = levelConfig.Number <= _persistentDataProvider.ProgressData.LastUnlockedLevel;
    }

    public void OnDetach(LevelButtonUIView view) => view.Button.onClick.RemoveAllListeners();

    private void OnLevelButtonClick(LevelConfig config)
    {
      _levelDataProvider.SetCurrentLevel(config);
      _stateMachine.Enter<LoadGameState>();
    }
  }
}