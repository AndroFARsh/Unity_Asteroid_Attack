using Code.Game.Cameras.Services;
using Entitas;
using UnityEngine;

namespace Code.Game.Cameras.Systems
{
  public class TeleportObjectOnExitOfScreenBoundsSystem : IExecuteSystem
  {
    private readonly ICameraProvider _cameraProvider;
    private readonly IGroup<GameEntity> _entities;

    public TeleportObjectOnExitOfScreenBoundsSystem(GameContext game, ICameraProvider cameraProvider)
    {
      _cameraProvider = cameraProvider;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.WorldPosition, 
          GameMatcher.MoveDirection));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        Vector2 position = entity.WorldPosition;
        Vector2 direction = entity.MoveDirection;

        if (IsExitOfTheScreen(position) && IsMoveOutOfTheScreen(direction, position))
        {
          if (position.x < _cameraProvider.ScreenBounds.min.x) position.x = _cameraProvider.ScreenBounds.max.x;
          else if (position.x > _cameraProvider.ScreenBounds.max.x) position.x = _cameraProvider.ScreenBounds.min.x;
          
          if (position.y < _cameraProvider.ScreenBounds.min.y) position.y = _cameraProvider.ScreenBounds.max.y;
          else if (position.y > _cameraProvider.ScreenBounds.max.y) position.y = _cameraProvider.ScreenBounds.min.y;
          
          entity.ReplaceWorldPosition(position);
        }
      }
    }

    private bool IsExitOfTheScreen(Vector2 position) => !_cameraProvider.ScreenBounds.Contains(position);

    private bool IsMoveOutOfTheScreen(Vector2 direction, Vector2 position) => 
      Vector3.Dot(direction, (_cameraProvider.ScreenCenter - position).normalized) < 0;
  }
}