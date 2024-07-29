using Code.Common.View.UI;
using Code.Infrastructure.UI;
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

    private IUIViewPresenter<LevelButtonUIView> _viewPresenter;
    
    [Inject]
    public void Construct(IUIViewPresenter<LevelButtonUIView> viewPresenter)
    {
      _viewPresenter = viewPresenter;
    }

    public void OnAttach(int level)
    {
      Level = level;
      _viewPresenter.OnAttach(this);
    }

    public void OnDetach()
    {
      _viewPresenter.OnDetach(this);
    }

    private void OnDestroy() => _viewPresenter.OnAttach(this);
  }
}