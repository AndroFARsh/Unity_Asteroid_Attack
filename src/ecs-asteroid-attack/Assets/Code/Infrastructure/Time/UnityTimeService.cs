using System;
using UnityEngine;

namespace Code.Infrastructure.Time
{
  public class UnityTimeService : ITimeService
  {
    private bool _paused;

    public float DeltaTime => !_paused ? UnityEngine.Time.deltaTime : 0;

    public DateTime UtcNow => DateTime.UtcNow;

    public void Pause()
    {
      _paused = true;
      Physics2D.simulationMode = SimulationMode2D.Script;
    } 
    
    public void Resume()
    {
      _paused = false;
      Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
    }
  }
}