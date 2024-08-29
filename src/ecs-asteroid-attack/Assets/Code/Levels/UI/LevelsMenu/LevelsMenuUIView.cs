using Code.Common.View.UI;
using Code.Infrastructure.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Levels.UI.LevelsMenu
{
  public class LevelsMenuUIView : MonoBehaviour, IUIView
  {
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private RectTransform _content;
    [SerializeField] private Button _backButton;
    
    public TextMeshProUGUI Title => _title;
    public RectTransform Content => _content;
    public Button Back => _backButton;
    
    private IUIViewPresenter<LevelsMenuUIView> _viewPresenter;
    
    [Inject]
    public void Construct(IUIViewPresenter<LevelsMenuUIView> viewPresenter)
    {
      _viewPresenter = viewPresenter;
    }

    private void Awake() => _viewPresenter.OnAttach(this);

    private void OnDestroy() => _viewPresenter.OnDetach(this);
  }
}