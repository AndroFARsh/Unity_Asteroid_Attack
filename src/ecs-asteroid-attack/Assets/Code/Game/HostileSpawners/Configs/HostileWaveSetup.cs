using System;
using System.Collections.Generic;

namespace Code.Game.HostileSpawners.Configs
{
  [Serializable]
  public class HostileWaveSetup
  {
    public List<HostileSetup> Hostiles;
    public float Cooldown = 1;
    public int MaxAlive = 3;
    public int Total = 5;
  }
}