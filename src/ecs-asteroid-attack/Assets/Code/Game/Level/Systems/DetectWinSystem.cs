using Code.Common.Extensions;
using Entitas;

namespace Code.Game.Level.Systems
{
  public class DetectWinSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _hostileEntities;
    private readonly IGroup<GameEntity> _hostileSpawnerEntities;
    private readonly IGroup<GameEntity> _levelEntities;
    private readonly IGroup<GameEntity> _playerEntities;

    public DetectWinSystem(GameContext game)
    {
      _hostileEntities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hostile));
      _hostileSpawnerEntities = game.GetGroup(GameMatcher.AllOf(GameMatcher.HostileSpawner));
      _playerEntities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
      _levelEntities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Level));
    }

    public void Execute()
    {
      if (_hostileSpawnerEntities.IsNotEmpty() || _hostileEntities.IsNotEmpty() || _playerEntities.IsEmpty()) return;

      foreach (GameEntity entity in _levelEntities)
      {
        entity.isWin = true;
        entity.isPause = true;
      }
    }
  }
}