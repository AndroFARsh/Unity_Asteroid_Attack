using System.Collections.Generic;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Entitas;

namespace Code.Game.HUD.Systems
{
  public class OpenPauseWindowSystem : ReactiveSystem<GameEntity>
  {
    private readonly IWindowService _windowService;

    public OpenPauseWindowSystem(GameContext game, IWindowService windowService) : base(game) =>
      _windowService = windowService;

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.PauseWindow.Added());

    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> levelUps)
    {
      foreach (GameEntity entity in levelUps)
      {
        _windowService.Push(WindowName.PauseWindow);
        entity.isPauseWindow = false;
      }
    }
  }
}