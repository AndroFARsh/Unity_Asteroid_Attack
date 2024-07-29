using UnityEngine;

namespace Code.Game.Cameras.Services
{
  public interface ICameraProvider
  {
    Camera MainCamera { get; }
    Bounds ScreenBounds { get; }
    
    Vector2 ScreenCenter { get; }
    float WorldScreenHeight { get; }
    float WorldScreenWidth { get; }
    void Retain(Camera camera);
    void Release();
  }
}