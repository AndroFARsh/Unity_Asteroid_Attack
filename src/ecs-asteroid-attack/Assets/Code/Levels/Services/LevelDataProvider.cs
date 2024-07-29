using Code.Levels.Configs;
using UnityEngine;

namespace Code.Levels.Services
{
  public class LevelDataProvider : ILevelDataProvider
  {
    public string SceneName => LevelConfig.SceneName;
    
    public Vector3 PlayerSpawnPoint => LevelConfig.PlayerSpawnPoint;
    public LevelConfig LevelConfig { get; private set; }

    public void SetCurrentLevel(LevelConfig config) => LevelConfig = config;
  }
}