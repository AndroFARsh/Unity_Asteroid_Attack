using System;
using UnityEngine;

namespace Code.Game.HUD.Services
{
  class GameHUDService : IGameHUDService
  {
    public event Action WaveChanged;
    public int CurrentWave { get; private set; }
    public int TotalWave { get; private set; }
    
    public void UpdateWave(int current, int total)
    {
      CurrentWave = Mathf.Max(0, Mathf.Min(current, total));
      TotalWave = Mathf.Max(0, total);
      WaveChanged?.Invoke();
    }

    public event Action ScoreChanged;
    public int CurrentScore { get; private set; }
    
    public void UpdateScore(int score)
    {
      CurrentScore = Mathf.Max(0, score);
      ScoreChanged?.Invoke();
    }
    
    public event Action LiveChanged;
    public int CurrentLive { get; private set; }
    public int TotalLive { get; private set; }
    
    public void UpdateLives(int current, int total)
    {
      CurrentLive = Mathf.Max(0, Mathf.Min(current, total));
      TotalLive = Mathf.Max(0, total);
      LiveChanged?.Invoke();
    }
  }
}