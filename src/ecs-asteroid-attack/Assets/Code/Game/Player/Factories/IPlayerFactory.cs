using UnityEngine;

namespace Code.Game.Player.Factories
{
  public interface IPlayerFactory
  {
    GameEntity CreatePlayer(Vector3 at);
  }
}