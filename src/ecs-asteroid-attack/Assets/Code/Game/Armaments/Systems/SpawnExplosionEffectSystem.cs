using Code.Game.Explosions.Factories;
using Code.Infrastructure.Physics;
using Entitas;

namespace Code.Game.Armaments.Systems
{
  public class SpawnExplosionEffectSystem : IExecuteSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IExplosionFactory _explosionFactory;
    private readonly IGroup<GameEntity> _entities;

    public SpawnExplosionEffectSystem(GameContext game, IExplosionFactory explosionFactory)
    {
      _explosionFactory = explosionFactory;
      _entities = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Explosive,
          GameMatcher.ReadyToCleanUp,
          GameMatcher.Rigidbody2D));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
        _explosionFactory.CreateExplosion(entity.Rigidbody2D.position);
    }
  }
}