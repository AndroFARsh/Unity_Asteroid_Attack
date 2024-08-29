using Code.Infrastructure.StaticData;
using Code.Levels.Configs;
using UnityEngine;

namespace Code.Levels.Services
{
  public class LevelDataProvider : ILevelDataProvider
  {
    private readonly IStaticDataService _staticDataService;
    
    public int LevelIndex  { get; private set; }
    
    public string SceneName => LevelConfig.SceneName;
    
    public Vector3 PlayerSpawnPoint => LevelConfig.PlayerSpawnPoint;
    public LevelConfig LevelConfig => _staticDataService.GetLevelConfig(LevelIndex);

    LevelDataProvider(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public void SetCurrentLevel(int level) => LevelIndex = level;
  }
}