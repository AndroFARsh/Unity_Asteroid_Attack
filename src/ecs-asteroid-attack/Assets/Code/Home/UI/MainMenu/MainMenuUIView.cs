using Code.Common.View.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Home.UI.MainMenu
{
  public class MainMenuUIView : MonoBehaviour, IUIView
  {
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _version;
    [SerializeField] private Button _play;

    public TextMeshProUGUI Title => _title;
    public TextMeshProUGUI Version => _version;
    public Button Play => _play;
    
    private IUIViewService<MainMenuUIView> _viewService;
    
    [Inject]
    public void Construct(IUIViewService<MainMenuUIView> viewService)
    {
      _viewService = viewService;
    }

    private void Awake() => _viewService.OnAttach(this);

    private void OnDestroy() => _viewService.OnDetach(this);
  }
}