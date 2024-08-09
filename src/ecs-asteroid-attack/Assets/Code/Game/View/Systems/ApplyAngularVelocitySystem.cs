using Entitas;

namespace Code.Game.View.Systems
{
  public class ApplyAngularVelocitySystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public ApplyAngularVelocitySystem(GameContext game)
    {
      _entities = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Rigidbody2D, 
          GameMatcher.AngularVelocity));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        entity.Rigidbody2D.angularVelocity = entity.AngularVelocity;
      }
    }
  }
}