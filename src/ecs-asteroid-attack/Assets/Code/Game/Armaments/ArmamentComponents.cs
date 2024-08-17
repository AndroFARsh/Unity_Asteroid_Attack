using Entitas;

namespace Code.Game.Armaments
{
  [Game] public class ArmamentComponent : IComponent { }
  
  [Game] public class ProjectileComponent : IComponent { }
  
  [Game] public class PierceNumberComponent : IComponent { public int Value; }
  
  [Game] public class ContactRadiusComponent : IComponent { public float Value; }
}