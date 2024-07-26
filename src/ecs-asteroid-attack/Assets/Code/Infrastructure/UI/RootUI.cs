using Code.Infrastructure.WindowManagement.Services;
using UnityEngine;
using VContainer;

namespace Code.Infrastructure.UI
{
  public class RootUI : MonoBehaviour
  {
    [SerializeField] private WindowRoot _windowRoot;
    
    private IWindowService _windowService;
  
    [Inject]
    public void Construct(IWindowService windowService)
    {
      _windowService = windowService;
    }

    private void Awake() => _windowService.Retain(_windowRoot);
    
    private void OnDestroy() => _windowService.Release();
  }
}