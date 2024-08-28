using System;
using Code.Game.HUD.Services;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;

namespace Code.Game.HUD
{
  public class GameHUDPresenter : IUIViewPresenter<GameHUDView>
  {
    private readonly IWindowService _windowService;
    private readonly IGameHUDService _service;
    
    private Action _livesWave;
    private Action _scoreWave;
    
    GameHUDPresenter(IWindowService windowService, IGameHUDService service)
    {
      _windowService = windowService;
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

    private void OnMenuButton() => _windowService.Push(WindowName.PauseWindow);
  }
}