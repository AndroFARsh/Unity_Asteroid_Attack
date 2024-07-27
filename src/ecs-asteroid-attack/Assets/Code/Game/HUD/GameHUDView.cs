using Code.Common.View.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Game.HUD
{
  public class GameHUDView : MonoBehaviour, IUIView
  {
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _waves;
    [SerializeField] private TextMeshProUGUI _lives;
    [SerializeField] private Button _menuButton;
    
    private IUIViewService<GameHUDView> _viewService;

    public TextMeshProUGUI Score => _score;
    public TextMeshProUGUI Waves => _waves;
    public TextMeshProUGUI Lives => _lives;
    public Button Menu => _menuButton;

    [Inject]
    public void Construct(IUIViewService<GameHUDView> viewService)
    {
      _viewService = viewService;
    }

    private void Awake() => _viewService.OnAttach(this);
    
    private void OnDestroy() => _viewService.OnDetach(this);
  }
}