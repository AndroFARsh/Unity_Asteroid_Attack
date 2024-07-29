using UnityEngine;

namespace Code.Game.Common.Extensions
{
  public enum CollisionLayer
  {
    Player = 6,
    Hostiles = 7,
    Collectable = 9,
  }
  
  public static class CollisionExtensions
  {
    public static bool Matches(this Collider2D collider, LayerMask layerMask) =>
      ((1 << collider.gameObject.layer) & layerMask) != 0;

    public static int AsMask(this CollisionLayer layer) =>
      1 << (int)layer;
  }
}