using UnityEngine;

namespace Code.Game.Armaments.Factories
{
  public interface IArmamentFactory
  {
    GameEntity CreateProjectile(Vector2 at, Vector2 direction);
  }
}