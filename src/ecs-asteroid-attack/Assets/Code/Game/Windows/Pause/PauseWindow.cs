using Code.Infrastructure.UI;
using Code.Infrastructure.Windows;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Game.Windows.Pause
{
  public class PauseWindow : BaseWindow
  {
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;
    
    public Button Resume => _resumeButton;
    public Button Exit => _exitButton;
    
    private IUIViewPresenter<PauseWindow> _viewPresenter;
    
    [Inject]
    public void Construct(IUIViewPresenter<PauseWindow> viewPresenter)
    {
      _viewPresenter = viewPresenter;
    }

    protected override void OnResume() => _viewPresenter.OnAttach(this);

    protected override void OnPause() => _viewPresenter.OnDetach(this);
  }
}