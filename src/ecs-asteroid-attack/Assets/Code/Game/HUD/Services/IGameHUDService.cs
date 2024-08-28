using System;

namespace Code.Game.HUD.Services
{
  public interface IGameHUDService
  {
    event Action ScoreChanged;
    int CurrentScore { get; }
    int MaxScore { get; }
    int PrevScore { get; }

    void UpdateScore(int score, int prev, int max);
    
    event Action LiveChanged;
    int CurrentLive { get; }
    int TotalLive { get; }
    
    void UpdateLives(int current, int total);
  }
}