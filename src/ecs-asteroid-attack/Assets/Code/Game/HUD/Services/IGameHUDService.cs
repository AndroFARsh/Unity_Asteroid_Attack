using System;

namespace Code.Game.HUD.Services
{
  interface IGameHUDService
  {
    event Action WaveChanged;
    int CurrentWave { get; }
    int TotalWave { get; }

    void UpdateWave(int current, int total);
    
    event Action ScoreChanged;
    int CurrentScore { get; }
    
    void UpdateScore(int score);
    
    event Action LiveChanged;
    int CurrentLive { get; }
    int TotalLive { get; }
    
    void UpdateLives(int current, int total);
  }
}