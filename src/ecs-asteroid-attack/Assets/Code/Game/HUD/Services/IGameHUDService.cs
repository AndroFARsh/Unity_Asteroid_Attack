using System;

namespace Code.Game.HUD.Services
{
  interface IGameHUDService
  {
    event Action ScoreChanged;
    int CurrentScore { get; }
    
    void UpdateScore(int score);
    
    event Action LiveChanged;
    int CurrentLive { get; }
    int TotalLive { get; }
    
    void UpdateLives(int current, int total);
  }
}