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
    
    private Action _updateWave;
    private Action _livesWave;
    private Action _scoreWave;
    
    GameHUDPresenter(IWindowService windowService, IGameHUDService service)
    {
      _windowService = windowService;
      _service = service;
    }

    public void OnAttach(GameHUDView view)
    {
      _updateWave = () => { view.Waves.text = $"{_service.CurrentWave}/{_service.TotalWave}"; };
      _livesWave = () => { view.Lives.text = _service.CurrentLive.ToString(); };
      _scoreWave = () => { view.Score.text = _service.CurrentScore.ToString(); };

      _updateWave();
      _livesWave();
      _scoreWave();
      
      _service.WaveChanged += _updateWave;
      _service.LiveChanged += _livesWave;
      _service.ScoreChanged += _scoreWave;
      
      view.Menu.onClick.AddListener(OnMenuButton);
    }
    
    public void OnDetach(GameHUDView view)
    {
      _service.WaveChanged -= _updateWave;
      _service.LiveChanged -= _livesWave;
      _service.ScoreChanged -= _scoreWave;
      
      view.Menu.onClick.RemoveListener(OnMenuButton);
      
      _updateWave = null;
      _livesWave = null;
      _scoreWave = null;
    }

    private void OnMenuButton() => _windowService.Push(WindowName.PauseWindow);
  }
}