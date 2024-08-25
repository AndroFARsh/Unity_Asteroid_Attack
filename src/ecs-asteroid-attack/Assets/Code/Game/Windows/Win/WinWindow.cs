using Code.Game.Windows.GameOver;
using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Game.Windows.Win
{
  public class WinWindow : BaseWindow
  {
    [SerializeField] private TextMeshProUGUI _missionNameText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _exitButton;
    
    private IUIViewPresenter<WinWindow> _viewPresenter;

    public TextMeshProUGUI MissionName => _missionNameText;
    public TextMeshProUGUI Score => _scoreText;
    public Button Next => _nextButton;
    public Button Exit => _exitButton;
    
    [Inject]
    public void Construct(IUIViewPresenter<WinWindow> viewPresenter)
    {
      _viewPresenter = viewPresenter;
    }

    protected override void OnResume() => _viewPresenter.OnAttach(this);

    protected override void OnPause() => _viewPresenter.OnDetach(this);
  }
}