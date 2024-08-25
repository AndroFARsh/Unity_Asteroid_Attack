using System.Collections.Generic;
using Code.Infrastructure.Windows;
using Code.Infrastructure.Windows.Services;
using Entitas;

namespace Code.Game.HUD.Systems
{
  public class ShowGameOverWindowSystem : IExecuteSystem
  {
    private readonly IWindowService _windowService;
    private readonly IGroup<GameEntity> _entities;
    
    private readonly List<GameEntity> _buffer = new(1);

    public ShowGameOverWindowSystem(GameContext game, IWindowService windowService)
    {
      _windowService = windowService;
      _entities = game.GetGroup(
        GameMatcher
          .AllOf(GameMatcher.Level, GameMatcher.GameOver)
          .NoneOf(GameMatcher.GameOverWindowShown));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        _windowService.Push(WindowName.GameOverWindow);
        entity.isGameOverWindowShown = true;
      }
    }
  }
}