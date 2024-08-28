using Code.Common.Extensions;
using Code.Game.Player.Configs;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.PersistentData;
using Code.Infrastructure.StaticData;

namespace Code.Game.Level.Factories
{
  public class LevelInfoFactory : ILevelInfoFactory
  {
    private readonly IEntityFactory _entityFactory;
    private readonly IPersistentDataProvider _persistentDataProvider;
    private readonly IStaticDataService _staticDataService;

    public LevelInfoFactory(IEntityFactory entityFactory, IPersistentDataProvider persistentDataProvider, IStaticDataService staticDataService)
    {
      _entityFactory = entityFactory;
      _persistentDataProvider = persistentDataProvider;
      _staticDataService = staticDataService;
    }

    public GameEntity CreateInfo()
    {
      PlayerConfig config = _staticDataService.GetPlayerConfig();
      return _entityFactory.CreateEntity<GameEntity>()
        .With(e => e.isLevel = true)
        .AddCurrentScore(0)
        .AddPreviousScore(_persistentDataProvider.ProgressData?.LastScore ?? 0)
        .AddPlayerTotalLive(config.MaxLives)
        .AddPlayerCurrentLive(config.MaxLives)
        ;
    }
  }
}