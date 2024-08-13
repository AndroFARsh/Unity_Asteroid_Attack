using Entitas;

namespace Code.Game.Player.Systems
{
  public class AnimatePlayerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _players;
    private readonly IGroup<InputEntity> _inputs;

    public AnimatePlayerSystem(GameContext game, InputContext input)
    {
      _players = game.GetGroup(GameMatcher.AllOf(
        GameMatcher.Player, 
        GameMatcher.Velocity,
        GameMatcher.CombustionAnimator
      ));
      _inputs = input.GetGroup(InputMatcher.Input);
    }

    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      foreach (GameEntity player in _players)
      {
        if (input.hasThrottle && input.Throttle < 0)
        {
          bool slowingDown = player.Velocity.SqrMagnitude() > float.Epsilon;
          player.CombustionAnimator.RunLeft(slowingDown);
          player.CombustionAnimator.RunRight(slowingDown);
          player.CombustionAnimator.RunMain(false);
        }
        else if (input.hasThrottle || input.hasYaw)
        {
          player.CombustionAnimator.RunMain(input.hasThrottle && input.Throttle > 0);
          player.CombustionAnimator.RunLeft(input.hasYaw && input.Yaw < 0);
          player.CombustionAnimator.RunRight(input.hasYaw && input.Yaw > 0);
        }
        else
        {
          player.CombustionAnimator.RunLeft(false);
          player.CombustionAnimator.RunRight(false);
          player.CombustionAnimator.RunMain(false);
        }
      }
    }
  }
}