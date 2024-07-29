using UnityEngine;

namespace Code.Game.Cameras.Services
{
  public class CameraProvider : ICameraProvider
  {
    public Camera MainCamera { get; private set; }
    public Bounds ScreenBounds { get; private set; }
    
    public Vector2 ScreenCenter { get; private set;  }
    public float WorldScreenHeight { get; private set; }
    public float WorldScreenWidth { get; private set; }

    public void Retain(Camera camera)
    {
      MainCamera = camera;

      RefreshBoundaries();
    }
    
    public void Release()
    {
      MainCamera = null;
    }

    private void RefreshBoundaries()
    {
      Vector2 bottomLeft = MainCamera.ViewportToWorldPoint(new Vector3(0, 0, MainCamera.nearClipPlane));
      Vector2 topRight = MainCamera.ViewportToWorldPoint(new Vector3(1, 1, MainCamera.nearClipPlane));

      ScreenCenter = new Vector2((topRight.x + bottomLeft.x) * 0.5f, (topRight.y + bottomLeft.y) * 0.5f); 
      WorldScreenWidth = topRight.x - bottomLeft.x;
      WorldScreenHeight = topRight.y - bottomLeft.y;
      ScreenBounds = new Bounds(ScreenCenter, new Vector2(WorldScreenWidth, WorldScreenHeight));
    }
  }
}