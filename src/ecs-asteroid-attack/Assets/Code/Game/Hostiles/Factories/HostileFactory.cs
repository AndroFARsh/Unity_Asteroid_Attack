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
    
    public GameEntity CreateHostile(HostileName name)
    {
      HostileConfig config = _staticDataService.GetHostileName(name);

      Vector2 at = PickRandomSpawnPosition();
      return _entityFactory.Create<GameEntity>()
          .With(e => e.isHostile = true)
          .AddHostileName(name)
          .With(e => e.isAsteroid = (name | HostileName.Asteroid) > 0)
          .AddTorque(PickRandomTorque(config))
          .AddForce(PickRandomForce(config, at))
          .AddWorldPosition(at)
          .AddViewPrefab(config.ViewPrefabs.PickRandom())
        ;
    }

    private float PickRandomTorque(HostileConfig config)
    {
      float direction = _randomService.Range(0, 2) == 0 ? -1f : 1f; 
      float speed = _randomService.Range(config.MinTorqueImpuls, config.MaxTorqueImpuls);
      return direction * speed;
    }

    private Vector2 PickRandomForce(HostileConfig config, Vector2 at)
    {
      Bounds bounds = _cameraProvider.ScreenBounds;
      Vector2 target = new(
        _randomService.Range(bounds.center.x - bounds.extents.x * 0.3f, bounds.center.x + bounds.extents.x * 0.3f),
        _randomService.Range(bounds.center.y - bounds.extents.y * 0.3f, bounds.center.y + bounds.extents.y * 0.3f));

      float speed = _randomService.Range(config.MinMoveImpuls, config.MaxMoveImpuls);
      Debug.Log($"Speed: {speed}");
      return (target - at).normalized * speed;
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