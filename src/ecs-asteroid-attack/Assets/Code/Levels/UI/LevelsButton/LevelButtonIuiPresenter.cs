using Code.Common.View.UI;
using Code.Infrastructure.States;
using Code.Infrastructure.StaticData;
using Code.Infrastructure.UI;
using Code.Levels.Configs;
using Code.Project.States;
using UnityEngine;

namespace Code.Levels.UI.LevelsButton
{
  public class LevelButtonIuiPresenter : IUIViewPresenter<LevelButtonUIView>
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IStateMachine _stateMachine;

    public LevelButtonIuiPresenter(IStaticDataService staticDataService, IStateMachine stateMachine)
    {
      _staticDataService = staticDataService;
      _stateMachine = stateMachine;
    }
    
    public void OnAttach(LevelButtonUIView view)
    {
      LevelConfig levelConfig = _staticDataService.GetLevelConfig(view.Level);
      view.Title.text = levelConfig.Name;
      view.Subtitle.text = $"Level {levelConfig.Number+1}";
      view.Button.onClick.AddListener(() => { OnLevelButtonClick(levelConfig); });
    }

    public void OnDetach(LevelButtonUIView view) => view.Button.onClick.RemoveAllListeners();

    private void OnLevelButtonClick(LevelConfig config) =>
      _stateMachine.Enter<LoadGameState, LevelConfig>(config);
  }
}