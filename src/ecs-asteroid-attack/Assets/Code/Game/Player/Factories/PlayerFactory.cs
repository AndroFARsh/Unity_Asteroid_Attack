using Code.Common.EntityFactories;
using Code.Common.Extensions;
using Code.Game.Player.Configs;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Game.Player.Factories
{
  public class PlayerFactory : IPlayerFactory
  {
    private readonly IEntityFactory _entityFactory;
    private readonly IStaticDataService _staticDataService;

    public PlayerFactory(IEntityFactory entityFactory, IStaticDataService staticDataService)
    {
      _entityFactory = entityFactory;
      _staticDataService = staticDataService;
    }

    public GameEntity CreatePlayer(Vector3 at)
    {
      PlayerConfig config = _staticDataService.GetPlayerConfig();
      return _entityFactory.Create<GameEntity>()
        .With(e => e.isPlayer = true)
        .AddPlayerConfig(config)
        .AddWorldPosition(at)
        .AddVelocity(Vector2.zero)
        .AddAngularVelocity(0)
        .AddViewPrefab(config.ViewPrefab)
        .With(e => e.isExplosive = true)
        ;
    }
  }
}