using System;
using Code.Game.Hostiles;

namespace Code.Game.HostileSpawners.Configs
{
  [Serializable]
  public class HostileSetup
  {
    public HostileName Name;
    public float Probability;
  }
}