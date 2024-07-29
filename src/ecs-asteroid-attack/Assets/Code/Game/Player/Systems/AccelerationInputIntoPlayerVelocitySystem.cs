using Code.Infrastructure.Time;
using Entitas;
using UnityEngine;

namespace Code.Game.Player.Systems
{
  public class AccelerationInputIntoPlayerVelocitySystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _players;
    private readonly IGroup<InputEntity> _inputs;

    public AccelerationInputIntoPlayerVelocitySystem(GameContext game, InputContext input, ITimeService timeService)
    {
      _timeService = timeService;
      _players = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Player,
          GameMatcher.MoveAcceleration,
          GameMatcher.MoveVelocity,
          GameMatcher.MaxMoveSpeed));
      _inputs = input.GetGroup(InputMatcher.Input);
    }

    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      foreach (GameEntity player in _players)
      {
        if (input.hasAcceleration)
        {
          player.ReplaceMoveVelocity(
            Mathf.Clamp(
              player.MoveVelocity + input.Acceleration * player.MoveAcceleration * _timeService.DeltaTime,
              0,
              player.MaxMoveSpeed
            )
          );
        }

        player.isMoving = Mathf.Abs(player.MoveVelocity) > float.Epsilon;
      }
    }
  }
}