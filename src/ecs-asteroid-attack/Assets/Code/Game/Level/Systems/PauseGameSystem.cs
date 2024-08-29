using System.Collections.Generic;
using Code.Infrastructure.Time;
using Entitas;

namespace Code.Game.Level.Systems
{
  public class PauseGameSystem : ReactiveSystem<GameEntity>
  {
    private readonly ITimeService _timeService;

    public PauseGameSystem(GameContext game, ITimeService timeService) : base(game)
    {
      _timeService = timeService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.Pause.Added());

    protected override bool Filter(GameEntity entity) => entity.isPause;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity _ in entities)
        _timeService.Pause();
    }
  }
}