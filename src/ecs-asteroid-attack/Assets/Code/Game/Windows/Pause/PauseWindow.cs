using Code.Common.View.UI;
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
    
    private IUIViewService<PauseWindow> _viewService;
    
    [Inject]
    public void Construct(IUIViewService<PauseWindow> viewService)
    {
      _viewService = viewService;
    }

    protected override void OnResume() => _viewService.OnAttach(this);

    protected override void OnPause() => _viewService.OnDetach(this);
  }
}