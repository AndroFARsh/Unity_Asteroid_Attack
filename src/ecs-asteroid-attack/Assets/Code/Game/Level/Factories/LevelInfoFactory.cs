using Code.Common.Extensions;
using Code.Game.Player.Configs;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.Progress;
using Code.Infrastructure.StaticData;

namespace Code.Game.Level.Factories
{
  public class LevelInfoFactory : ILevelInfoFactory
  {
    private readonly IEntityFactory _entityFactory;
    private readonly IProgressDataProvider _progressDataProvider;
    private readonly IStaticDataService _staticDataService;

    public LevelInfoFactory(IEntityFactory entityFactory, IProgressDataProvider progressDataProvider, IStaticDataService staticDataService)
    {
      _entityFactory = entityFactory;
      _progressDataProvider = progressDataProvider;
      _staticDataService = staticDataService;
    }

    public GameEntity CreateInfo()
    {
      PlayerConfig config = _staticDataService.GetPlayerConfig();
      return _entityFactory.CreateEntity<GameEntity>()
        .With(e => e.isLevel = true)
        .AddCurrentScore(0)
        .AddPreviousScore(_progressDataProvider.ProgressData?.LastScore ?? 0)
        .AddPlayerTotalLive(config.MaxLives)
        .AddPlayerCurrentLive(config.MaxLives)
        ;
    }
  }
}