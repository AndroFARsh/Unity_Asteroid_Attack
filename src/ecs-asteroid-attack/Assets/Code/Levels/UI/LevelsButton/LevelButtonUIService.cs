using Code.Common.View.UI;
using Code.Infrastructure.StaticData;
using Code.Levels.Configs;
using UnityEngine;

namespace Code.Levels.UI.LevelsButton
{
  public class LevelButtonUIService : IUIViewService<LevelButtonUIView>
  {
    private readonly IStaticDataService _staticDataService;

    public LevelButtonUIService(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }
    
    public void OnAttach(LevelButtonUIView view)
    {
      LevelConfig levelConfig = _staticDataService.GetLevelConfig(view.Level);
      view.Title.text = levelConfig.Name;
      view.Subtitle.text = $"Level {levelConfig.Number+1}";
      view.Button.onClick.AddListener(() => { OnLevelButtonClick(levelConfig); });
    }

    public void OnDetach(LevelButtonUIView view) => view.Button.onClick.RemoveAllListeners();

    private void OnLevelButtonClick(LevelConfig config)
    {
      Debug.Log( $"Level: {config.Number+1} Name: {config.Name}");
    }
  }
}