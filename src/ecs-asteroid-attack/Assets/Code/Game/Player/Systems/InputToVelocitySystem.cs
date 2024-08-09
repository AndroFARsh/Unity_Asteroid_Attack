using Code.Game.Player.Configs;
using Code.Infrastructure.Time;
using Entitas;
using UnityEngine;

namespace Code.Game.Player.Systems
{
  public class InputToVelocitySystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _players;
    private readonly IGroup<InputEntity> _inputs;

    public InputToVelocitySystem(GameContext game, InputContext input, ITimeService timeService)
    {
      _timeService = timeService;
      _players = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Velocity,
          GameMatcher.Player,
          GameMatcher.Rigidbody2D,
          GameMatcher.PlayerConfig));
      _inputs = input.GetGroup(InputMatcher.Input);
    }

    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      foreach (GameEntity player in _players)
      {
        if (input.hasThrottle)
        {
          Vector2 forward = player.Rigidbody2D.transform.up; 
          Vector2 force = input.Throttle * player.PlayerConfig.MoveAcceleration * forward;

          Vector2 newVelocity = NormalizeVelocity(player.Velocity + force, forward, player.PlayerConfig);
          
          player.ReplaceVelocity(newVelocity);
        }
      }
    }

    private static Vector2 NormalizeVelocity(Vector2 newVelocity, Vector2 forward, PlayerConfig config)
    {
      Vector2 newNormalizedVelocity = newVelocity.normalized;
      float speed = newVelocity.magnitude;

      if (Vector2.Dot(forward, newNormalizedVelocity) < 0 && speed > 0)
        return Vector2.zero;
      if (speed > config.MaxMoveSpeed)
        return newNormalizedVelocity * config.MaxMoveSpeed;
      
      return newVelocity;
    }
  }
}