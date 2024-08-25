using Code.Common.Extensions;
using Code.Game.Player.Configs;
using Code.Infrastructure.EntityFactories;
using Code.Infrastructure.Progress;
using Code.Infrastructure.StaticData;

namespace Code.Game.GameState.Factories
{
  public class GameStateFactory : IGameStateFactory
  {
    private readonly IEntityFactory _entityFactory;
    private readonly IProgressDataProvider _progressDataProvider;
    private readonly IStaticDataService _staticDataService;

    public GameStateFactory(IEntityFactory entityFactory, IProgressDataProvider progressDataProvider, IStaticDataService staticDataService)
    {
      _entityFactory = entityFactory;
      _progressDataProvider = progressDataProvider;
      _staticDataService = staticDataService;
    }

    public GameEntity CreateState()
    {
      PlayerConfig config = _staticDataService.GetPlayerConfig();
      return _entityFactory.CreateEntity<GameEntity>()
        .With(e => e.isGameState = true)
        .AddCurrentScore(0)
        .AddPreviousScore(_progressDataProvider.ProgressData?.LastScore ?? 0)
        .AddPlayerTotalLive(config.MaxLives)
        .AddPlayerCurrentLive(config.MaxLives)
        ;
    }
  }
}