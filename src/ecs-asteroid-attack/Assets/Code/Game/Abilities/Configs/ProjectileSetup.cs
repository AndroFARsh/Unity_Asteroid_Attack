using System;

namespace Code.Game.Abilities.Configs
{
  [Serializable]
  public class ProjectileSetup
  {
    public int NumberPerSpawn = 1;
    public int Pierce = 1;
    
    public float Speed;
    public float Lifetime;
    public float ContactRadius;
    
    public float OrbitRadius;
  }
}