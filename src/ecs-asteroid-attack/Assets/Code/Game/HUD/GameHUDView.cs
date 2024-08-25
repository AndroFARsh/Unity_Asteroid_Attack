using Code.Common.View.UI;
using Code.Infrastructure.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Game.HUD
{
  public class GameHUDView : MonoBehaviour, IUIView
  {
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _lives;
    [SerializeField] private Button _menuButton;
    
    private IUIViewPresenter<GameHUDView> _viewPresenter;

    public TextMeshProUGUI Score => _score;
    public TextMeshProUGUI Lives => _lives;
    public Button Menu => _menuButton;

    [Inject]
    public void Construct(IUIViewPresenter<GameHUDView> viewPresenter)
    {
      _viewPresenter = viewPresenter;
    }

    private void Awake() => _viewPresenter.OnAttach(this);
    
    private void OnDestroy() => _viewPresenter.OnDetach(this);
  }
}