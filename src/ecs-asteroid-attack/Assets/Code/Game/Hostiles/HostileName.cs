using System;

namespace Code.Game.Hostiles
{
  [Flags]
  public enum HostileName
  {
    Unknown = 0,
    SmallAsteroid = 1,
    LargeAsteroid = 2,
    
    Asteroid = SmallAsteroid | LargeAsteroid
  }
}