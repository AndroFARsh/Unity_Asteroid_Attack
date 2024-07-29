using Code.Game.Cameras.Services;
using UnityEngine;
using VContainer;

namespace Code.Game.Cameras.Behaviours
{
  public class CameraRegistrar : MonoBehaviour
  {
    [SerializeField] private Camera _camera;
    private ICameraProvider _cameraProvider;

    [Inject]
    public void Construct(ICameraProvider cameraProvider)
    {
      _cameraProvider = cameraProvider;
    }

    private void Awake()
    {
      if (_camera == null) _camera = GetComponentInChildren<Camera>();
      if (_camera != null) _cameraProvider.Retain(_camera);
    }

    private void OnDestroy() => _cameraProvider.Release();
  }
}