using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Game.Windows.GameOver
{
  public class GameOverWindow : BaseWindow
  {
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    
    private IUIViewPresenter<GameOverWindow> _viewPresenter;

    public TextMeshProUGUI Score => _scoreText;
    public Button Restart => _restartButton;
    public Button Exit => _exitButton;
    
    [Inject]
    public void Construct(IUIViewPresenter<GameOverWindow> viewPresenter)
    {
      _viewPresenter = viewPresenter;
    }

    protected override void OnResume() => _viewPresenter.OnAttach(this);

    protected override void OnPause() => _viewPresenter.OnDetach(this);
  }
}