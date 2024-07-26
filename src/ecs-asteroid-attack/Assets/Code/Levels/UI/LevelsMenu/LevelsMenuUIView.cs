using Code.Common.View.UI;
using TMPro;
using UnityEngine;
using VContainer;

namespace Code.Levels.UI.LevelsMenu
{
  public class LevelsMenuUIView : MonoBehaviour, IUIView
  {
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private RectTransform _content;

    public TextMeshProUGUI Title => _title;
    public RectTransform Content => _content;
    
    private IUIViewService<LevelsMenuUIView> _viewService;
    
    [Inject]
    public void Construct(IUIViewService<LevelsMenuUIView> viewService)
    {
      _viewService = viewService;
    }

    private void Awake() => _viewService.OnAttach(this);

    private void OnDestroy() => _viewService.OnDetach(this);
  }
}