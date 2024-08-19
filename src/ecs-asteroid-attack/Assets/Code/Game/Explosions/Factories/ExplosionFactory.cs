using Code.Common.EntityFactories;
using Code.Common.Extensions;
using UnityEngine;

namespace Code.Game.Explosions.Factories
{
  public class ExplosionFactory : IExplosionFactory
  {
    private readonly IEntityFactory _factory;

    public ExplosionFactory(IEntityFactory factory)
    {
      _factory = factory;
    }
    public GameEntity CreateExplosion(Vector2 at)
    {
      return _factory.Create<GameEntity>()
        .With(e => e.isExplosion = true)
        .AddWorldPosition(at)
        .AddViewPath("Game/Effects/Explosion")
        .AddSelfDestroyTimer(0.3f);
    }
  }
}