using UnityEngine;

namespace Code.Game.Hostiles.Factories
{
  public interface IHostileFactory
  {
    GameEntity CreateHostileShard(HostileName name, Vector2 at, Vector2 direction);
    
    GameEntity CreateHostile(HostileName name);
  }
}