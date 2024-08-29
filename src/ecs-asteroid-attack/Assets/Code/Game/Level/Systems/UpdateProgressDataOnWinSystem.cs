using Code.Infrastructure.PersistentData;
using Entitas;
using UnityEngine;

namespace Code.Game.Level.Systems
{
  public class UpdateProgressDataOnWinSystem: ITearDownSystem
  {
    private readonly IPersistentDataProvider _persistentDataProvider;
    private readonly IGroup<GameEntity> _entity;

    UpdateProgressDataOnWinSystem(GameContext game, IPersistentDataProvider persistentDataProvider)
    {
      _persistentDataProvider = persistentDataProvider;
      _entity = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Win,
          GameMatcher.CurrentScore,
          GameMatcher.MaxScore
        ));
    }

    public void TearDown()
    {
      foreach (GameEntity entity in _entity)
      {
        if (entity.isNextLevel)
        {
          _persistentDataProvider.ProgressData.Score = entity.CurrentScore;
        }
        else
        {
          _persistentDataProvider.ProgressData.Score = 0;
          _persistentDataProvider.ProgressData.PrevScore = entity.CurrentScore;
          _persistentDataProvider.ProgressData.MaxScore = Mathf.Max(entity.CurrentScore, entity.MaxScore);
        }
      }
    }
  }
}