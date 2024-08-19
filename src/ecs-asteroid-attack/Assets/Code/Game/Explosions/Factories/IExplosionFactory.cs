using UnityEngine;

namespace Code.Game.Explosions.Factories
{
  public interface IExplosionFactory
  {
    GameEntity CreateExplosion(Vector2 at);
  }
}