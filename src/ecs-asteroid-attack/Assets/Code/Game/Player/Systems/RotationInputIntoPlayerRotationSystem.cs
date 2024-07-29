using Entitas;

namespace Code.Game.Player.Systems
{
  public class RotationInputIntoPlayerRotationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _players;
    private readonly IGroup<InputEntity> _inputs;

    public RotationInputIntoPlayerRotationSystem(GameContext game, InputContext input)
    {
      _players = game.GetGroup(GameMatcher.Player);
      _inputs = input.GetGroup(InputMatcher.Input);
    }

    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      foreach (GameEntity player in _players)
      {
        player.isRotating = input.hasRotation;
        if (input.hasRotation)
          player.ReplaceRotateDirection(input.Rotation);
      }
    }
  }
}