using Code.Common.View.UI;
using Code.Infrastructure.UI;
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
    [SerializeField] private Button _settings;
    [SerializeField] private Button _credits;

    public TextMeshProUGUI Title => _title;
    public TextMeshProUGUI Version => _version;
    public Button Play => _play;
    
    public Button Settings => _settings;
    
    public Button Credits => _credits;
    
    private IUIViewPresenter<MainMenuUIView> _viewPresenter;
    
    [Inject]
    public void Construct(IUIViewPresenter<MainMenuUIView> viewPresenter)
    {
      _viewPresenter = viewPresenter;
    }

    private void Awake() => _viewPresenter.OnAttach(this);

    private void OnDestroy() => _viewPresenter.OnDetach(this);
  }
}