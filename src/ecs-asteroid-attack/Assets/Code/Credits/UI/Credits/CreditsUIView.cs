using Code.Common.View.UI;
using Code.Infrastructure.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.Credits.UI.Credits
{
  public class CreditsUIView : MonoBehaviour, IUIView
  {
    [SerializeField] private TextMeshProUGUI _version;
    [SerializeField] private Button _back;
    [SerializeField] private Button _gitHub;

    public TextMeshProUGUI Version => _version;
    
    public Button GitHub => _gitHub;
    public Button Back => _back;
    
    private IUIViewPresenter<CreditsUIView> _viewPresenter;
    
    [Inject]
    public void Construct(IUIViewPresenter<CreditsUIView> viewPresenter)
    {
      _viewPresenter = viewPresenter;
    }

    private void Awake() => _viewPresenter.OnAttach(this);

    private void OnDestroy() => _viewPresenter.OnDetach(this);
  }
}