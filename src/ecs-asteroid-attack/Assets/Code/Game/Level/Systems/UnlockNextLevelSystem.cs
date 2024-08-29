using System.Collections.Generic;
using Code.Infrastructure.PersistentData;
using Code.Infrastructure.StaticData;
using Code.Levels.Services;
using Entitas;

namespace Code.Game.Level.Systems
{
  public class UnlockNextLevelSystem : ReactiveSystem<GameEntity>
  {
    private readonly IPersistentDataProvider _persistentDataProvider;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IStaticDataService _staticDataService;

    public UnlockNextLevelSystem(GameContext game, 
      IPersistentDataProvider persistentDataProvider,
      ILevelDataProvider levelDataProvider,
      IStaticDataService staticDataService) : base(game)
    {
      _persistentDataProvider = persistentDataProvider;
      _levelDataProvider = levelDataProvider;
      _staticDataService = staticDataService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.Win.Added());

    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity _ in entities)
      {
        int nextLevel = _levelDataProvider.LevelIndex + 1;
        if (nextLevel < _staticDataService.NumberOfLevels)
        {
          _persistentDataProvider.ProgressData.LastUnlockedLevel = nextLevel;
        }
      }
    }
  }
}