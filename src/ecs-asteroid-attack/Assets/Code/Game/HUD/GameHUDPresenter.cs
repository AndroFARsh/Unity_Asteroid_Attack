using System;
using Code.Game.HUD.Services;
using Code.Game.Level;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.UI;

namespace Code.Game.HUD
{
  public class GameHUDPresenter : IUIViewPresenter<GameHUDView>
  {
    private readonly IEntityFactory _entityFactory;
    private readonly IGameHUDService _service;
    
    private Action _livesWave;
    private Action _scoreWave;
    
    GameHUDPresenter(IEntityFactory entityFactory, IGameHUDService service)
    {
      _entityFactory = entityFactory;
      _service = service;
    }

    public void OnAttach(GameHUDView view)
    {
      _livesWave = () => { view.Lives.text = $"{_service.CurrentLive}/{_service.TotalLive}"; };
      _scoreWave = () =>
      {
        view.CurrentScore.text = _service.CurrentScore.ToString();
        view.PreviousScore.text = _service.PrevScore.ToString();
        view.MaxScore.text = _service.MaxScore.ToString();
      };
      
      _livesWave();
      _scoreWave();
      
      _service.LiveChanged += _livesWave;
      _service.ScoreChanged += _scoreWave;
      
      view.Menu.onClick.AddListener(OnMenuButton);
    }
    
    public void OnDetach(GameHUDView view)
    {
      _service.LiveChanged -= _livesWave;
      _service.ScoreChanged -= _scoreWave;
      
      view.Menu.onClick.RemoveListener(OnMenuButton);
      
      _livesWave = null;
      _scoreWave = null;
    }

    private void OnMenuButton() => _entityFactory.CreateEntity<GameEntity>()
      .AddRoute(RouteName.Pause);
  }
}