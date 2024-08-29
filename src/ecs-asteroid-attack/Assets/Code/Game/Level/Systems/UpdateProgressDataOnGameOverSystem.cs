using Code.Infrastructure.PersistentData;
using Entitas;
using UnityEngine;

namespace Code.Game.Level.Systems
{
  public class UpdateProgressDataOnGameOverSystem: ITearDownSystem
  {
    private readonly IPersistentDataProvider _persistentDataProvider;
    private readonly IGroup<GameEntity> _entity;

    UpdateProgressDataOnGameOverSystem(GameContext game, IPersistentDataProvider persistentDataProvider)
    {
      _persistentDataProvider = persistentDataProvider;
      _entity = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.GameOver,
          GameMatcher.CurrentScore,
          GameMatcher.MaxScore
        ));
    }

    public void TearDown()
    {
      foreach (GameEntity entity in _entity)
      {
        _persistentDataProvider.ProgressData.Score = 0;
        _persistentDataProvider.ProgressData.PrevScore = entity.CurrentScore;
        _persistentDataProvider.ProgressData.MaxScore = Mathf.Max(entity.CurrentScore, entity.MaxScore);
      }
    }
  }
}