using System.Collections.Generic;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Entitas;

namespace Code.Game.HUD.Systems
{
  public class OpenGameOverWindowSystem : ReactiveSystem<GameEntity>
  {
    private readonly IWindowService _windowService;

    public OpenGameOverWindowSystem(GameContext game, IWindowService windowService) : base(game) =>
      _windowService = windowService;

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.GameOver.Added());

    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> levelUps)
    {
      foreach (GameEntity _ in levelUps)
        _windowService.Push(WindowName.GameOverWindow);
    }
  }
}