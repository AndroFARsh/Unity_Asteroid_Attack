using Code.Common.View.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Levels.UI.LevelsButton
{
  public class LevelButtonUIView : MonoBehaviour, IUIView
  {
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _subtitle;
    [SerializeField] private Button _button;

    public TextMeshProUGUI Title => _title;
    public TextMeshProUGUI Subtitle => _subtitle;
    public Button Button => _button;
    public int Level { get; private set; }

    private IUIViewService<LevelButtonUIView> _viewService;
    
    [Inject]
    public void Construct(IUIViewService<LevelButtonUIView> viewService)
    {
      _viewService = viewService;
    }

    public void OnAttach(int level)
    {
      Level = level;
      _viewService.OnAttach(this);
    }

    public void OnDetach()
    {
      _viewService.OnDetach(this);
    }

    private void OnDestroy() => _viewService.OnAttach(this);
  }
}