using Code.Common.EntityFactories;
using Code.Common.Extensions;
using Code.Game.Abilities.Configs;
using Code.Infrastructure.StaticData;

namespace Code.Game.Abilities.Factories
{
  public class AbilityFactory : IAbilityFactory
  {
    private readonly IEntityFactory _factory;
    private readonly IStaticDataService _staticDataService;

    public AbilityFactory(IEntityFactory factory, IStaticDataService staticDataService)
    {
      _factory = factory;
      _staticDataService = staticDataService;
    }
    
    public GameEntity CreateAbility(AbilityName name, ulong ownerId)
    {
      AbilityConfig config = _staticDataService.GetAbilityConfig(name);
      return _factory.Create<GameEntity>()
          .With(e => e.isAbility = true)
          .AddAbilityName(name)
          .AddOwnerId(ownerId)
          .AddCooldownLeft(0)
          .With(e => e.isProjectileAbility = name == AbilityName.Projectile)
          .AddCooldownTime(config.Cooldown)
        ;
    }
  }
}