using Code.Common.Extensions;
using Code.Game.Abilities;
using Code.Game.Abilities.Configs;
using Code.Game.Common.Extensions;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Game.Armaments.Factories
{
  public class ArmamentFactory : IArmamentFactory
  {
    private readonly IEntityFactory _factory;
    private readonly IStaticDataService _staticDataService;

    public ArmamentFactory(IEntityFactory factory, IStaticDataService staticDataService)
    {
      _factory = factory;
      _staticDataService = staticDataService;
    }

    public GameEntity CreateProjectile(Vector2 at, Vector2 direction)
    {
      AbilityConfig config = _staticDataService.GetAbilityConfig(AbilityName.Projectile);
      return _factory.CreateEntity<GameEntity>()
          .With(e => e.isArmament = true)
          .AddWorldPosition(at)
          .AddViewPrefab(config.ViewPrefabs)
          .AddForce(config.ProjectileSetup.Speed * direction)
          .AddPierceNumber(config.ProjectileSetup.Pierce)
          .AddContactRadius(config.ProjectileSetup.ContactRadius)
          .AddSelfDestroyTimer(config.ProjectileSetup.Lifetime)
          .AddLayerMask(CollisionLayer.Hostiles.AsMask())
        ;
    }
  }
}