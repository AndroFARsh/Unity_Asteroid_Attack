using Code.Levels.Configs;
using UnityEngine;

namespace Code.Levels.Services
{
  public interface ILevelDataProvider
  {
    Vector3 PlayerSpawnPoint { get; }

    string SceneName { get; }

    LevelConfig LevelConfig { get; }
    
    void SetCurrentLevel(LevelConfig config);
  }
}