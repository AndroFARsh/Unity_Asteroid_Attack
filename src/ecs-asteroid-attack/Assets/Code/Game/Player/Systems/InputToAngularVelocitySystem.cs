using Entitas;

namespace Code.Game.Player.Systems
{
  public class InputToAngularVelocitySystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _players;
    private readonly IGroup<InputEntity> _inputs;

    public InputToAngularVelocitySystem(GameContext game, InputContext input)
    {
      _players = game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.PlayerConfig));
      _inputs = input.GetGroup(InputMatcher.Input);
    }

    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      foreach (GameEntity player in _players)
      {
        player.ReplaceAngularVelocity(input.hasYaw ? input.Yaw * player.PlayerConfig.RotateSpeed : 0);
      }
    }
  }
}