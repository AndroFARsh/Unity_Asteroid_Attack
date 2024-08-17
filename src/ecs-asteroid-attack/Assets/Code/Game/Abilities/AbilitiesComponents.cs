using Entitas;

namespace Code.Game.Abilities
{
  [Game] public class AbilityComponent : IComponent { }
  
  [Game] public class AbilityNameComponent : IComponent { public AbilityName Value; }
  
  [Game] public class ProjectileAbilityComponent : IComponent { }
  
  [Game] public class OwnerIdComponent : IComponent { public ulong Value; }
  
}