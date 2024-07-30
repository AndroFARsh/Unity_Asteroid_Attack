using UnityEngine;

namespace Code.Common.Debugs
{
  public static class DebugTools
  {
    public static void DrawPoint(Vector3 p) => DrawPoint(p, Color.green);
    
    public static void DrawPoint(Vector3 p, Color color, float size = 0.5f, float duration = 0.0f)
    {
      Debug.DrawLine(p - Vector3.up * size, p + Vector3.up * size, color, duration);
      Debug.DrawLine(p - Vector3.right * size, p + Vector3.right * size, color, duration);
      Debug.DrawLine(p - Vector3.forward * size, p + Vector3.forward * size, color, duration);
    }

    public static void DrawVector(Vector3 p, Vector3 v) => DrawVector(p, v, Color.green);

    public static void DrawVector(Vector3 p, Vector3 v, Color color, float duration = 0.0f)
    {
      Debug.DrawLine(p, p + v, color, duration);
      DrawPoint(p, color, 0.3f, duration);
    }
  }
}