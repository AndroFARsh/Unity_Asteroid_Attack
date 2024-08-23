using Code.Common.EntityFactories;
using Code.Common.Extensions;
using Code.Game.Cameras.Services;
using Code.Game.Hostiles.Configs;
using Code.Infrastructure.Randoms;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Game.Hostiles.Factories
{
  public class HostileFactory : IHostileFactory
  {
    private const float SpawnDistanceGap = 1f;
    
    private readonly IEntityFactory _entityFactory;
    private readonly IStaticDataService _staticDataService;
    private readonly IRandomService _randomService;
    private readonly ICameraProvider _cameraProvider;

    public HostileFactory(
      IEntityFactory entityFactory, 
      IStaticDataService staticDataService, 
      IRandomService randomService, 
      ICameraProvider cameraProvider)
    {
      _entityFactory = entityFactory;
      _staticDataService = staticDataService;
      _randomService = randomService;
      _cameraProvider = cameraProvider;
    }

    public GameEntity CreateHostileShard(HostileName name, Vector2 at, Vector2 direction)
    {
      HostileConfig config = _staticDataService.GetHostileName(name);
      HostileName shardName = PickRandomShards(config);
      return CreateHostile(shardName)
        .ReplaceWorldPosition(at)
        .ReplaceForce(direction * PickRandomImpulse(config))
        .With(e => e.isShard = true);
    }

    public GameEntity CreateHostile(HostileName name)
    {
      HostileConfig config = _staticDataService.GetHostileName(name);

      Vector2 at = PickRandomSpawnPosition();
      int shards = PickRandomShardsNumber(config);
      return _entityFactory.Create<GameEntity>()
          .With(e => e.isHostile = true)
          .AddHostileName(name)
          .With(e => e.isAsteroid = (name | HostileName.Asteroid) > 0)
          .With(e => e.AddShards(shards), when: shards > 0)
          .AddTorque(PickRandomTorque(config))
          .AddForce(PickRandomDirection(at) * PickRandomImpulse(config))
          .AddWorldPosition(at)
          .AddViewPrefab(config.ViewPrefabs.PickRandom())
          .With(e => e.isExplosive = true)
        ;
    }

    private float PickRandomTorque(HostileConfig config)
    {
      float direction = _randomService.Range(0, 2) == 0 ? -1f : 1f; 
      float speed = _randomService.Range(config.MinTorqueImpuls, config.MaxTorqueImpuls);
      return direction * speed;
    }

    private HostileName PickRandomShards(HostileConfig config) => config.Shards.PickRandom();

    private int PickRandomShardsNumber(HostileConfig config) =>
      config.MinShards < config.MaxShards 
        ? _randomService.Range(config.MinShards, config.MaxShards)
        : Mathf.Max(0, config.MinShards);


    private float PickRandomImpulse(HostileConfig config) => _randomService.Range(config.MinMoveImpuls, config.MaxMoveImpuls);

    private Vector2 PickRandomDirection(Vector2 at)
    {
      Bounds bounds = _cameraProvider.ScreenBounds;
      Vector2 target = new(
        _randomService.Range(bounds.center.x - bounds.extents.x * 0.3f, bounds.center.x + bounds.extents.x * 0.3f),
        _randomService.Range(bounds.center.y - bounds.extents.y * 0.3f, bounds.center.y + bounds.extents.y * 0.3f));

      return (target - at).normalized;
    }

    private Vector2 PickRandomSpawnPosition() =>
      _randomService.Range(0, 2) == 0 
        ? HorizontalSpawnPosition() 
        : VerticalSpawnPosition();

    private Vector2 HorizontalSpawnPosition()
    {
      float x = _randomService.Range(0, 2) == 0
        ? _cameraProvider.ScreenBounds.min.x - SpawnDistanceGap
        : _cameraProvider.ScreenBounds.max.x + SpawnDistanceGap;
      
      float y = Random.Range(-_cameraProvider.WorldScreenHeight / 2, _cameraProvider.WorldScreenHeight / 2);

      return new Vector2(x, y);
    }

    private Vector2 VerticalSpawnPosition()
    {
      float y = _randomService.Range(0, 2) == 0
        ? _cameraProvider.ScreenBounds.min.y - SpawnDistanceGap
        : _cameraProvider.ScreenBounds.max.y + SpawnDistanceGap;

      float x = Random.Range(-_cameraProvider.WorldScreenWidth / 2, _cameraProvider.WorldScreenWidth / 2);

      return new Vector2(x, y);
    }
  }
}