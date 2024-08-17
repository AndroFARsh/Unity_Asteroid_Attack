using Entitas;

namespace Code.Game.Cooldowns
{
  [Game] public class CooldownTimeComponent : IComponent { public float Value; }
  
  [Game] public class CooldownLeftComponent : IComponent { public float Value; }
  
  [Game] public class CooldownUpComponent : IComponent { }
}