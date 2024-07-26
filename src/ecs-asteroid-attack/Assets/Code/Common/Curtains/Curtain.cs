using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Common.Curtains
{
  public class Curtain : MonoBehaviour, ICurtainService
  {
    [Tooltip("How fast should the texture be Faded In?")]
    [SerializeField] private float _fadeInDuration = 0.5f;
    [SerializeField] private AnimationCurve _fadeInCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    [Tooltip("How fast should the texture be Faded Out?")]
    [SerializeField] private float _fadeOutDuration = 0.5f;
    [SerializeField] private AnimationCurve _fadeOutCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);

    [SerializeField] private CanvasGroup _canvasGroup;
    
    private bool _inProgress;
    private bool _shown;
    
    public async UniTask Show()
    {
      if (_inProgress || _shown) return;
      
      gameObject.SetActive(true);
      
      _inProgress = true;
      _shown = true;
      
      float time = 0.0f;
      while (time < _fadeInDuration)
      {
        time += Time.deltaTime;
        _canvasGroup.alpha = _fadeInCurve.Evaluate(time / _fadeInDuration);
        
        await UniTask.NextFrame();
      }
            
      _inProgress = false;
    }

    public async UniTask Hide()
    {
      if (_inProgress || !_shown) return;

      _inProgress = true;
            
      float time = 0.0f;
      while (time < _fadeOutDuration)
      {
        time += Time.deltaTime;
        _canvasGroup.alpha = _fadeOutCurve.Evaluate(time / _fadeOutDuration);
                
        await UniTask.NextFrame();
      }
            
      _shown = false;
      _inProgress = false;
      
      gameObject.SetActive(false);
    }
  }
}