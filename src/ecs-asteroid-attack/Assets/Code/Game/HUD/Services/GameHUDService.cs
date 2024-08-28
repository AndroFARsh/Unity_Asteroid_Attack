using System;
using UnityEngine;

namespace Code.Game.HUD.Services
{
  class GameHUDService : IGameHUDService
  {
    public event Action ScoreChanged;
    public int CurrentScore { get; private set; }
    public int PrevScore { get; private set; }
    public int MaxScore { get; private set; }
    
    public void UpdateScore(int score, int prev, int max)
    {
      CurrentScore = Mathf.Max(0, score);
      PrevScore = Mathf.Max(0, prev);
      MaxScore = Mathf.Max(score, max);
      ScoreChanged?.Invoke();
    }
    
    public event Action LiveChanged;
    public int CurrentLive { get; private set; }
    public int TotalLive { get; private set; }
    
    public void UpdateLives(int current, int total)
    {
      CurrentLive = Mathf.Max(0, Mathf.Min(current+1, total));
      TotalLive = Mathf.Max(0, total);
      LiveChanged?.Invoke();
    }
  }
}