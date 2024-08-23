using Entitas;

namespace Code.Game.Hostiles
{
  [Game] public class HostileComponent : IComponent { }
  
  [Game] public class HostileNameComponent : IComponent { public HostileName Value; }
  
  [Game] public class AsteroidComponent : IComponent { }
  
  [Game] public class ShardComponent : IComponent { }
  
  [Game] public class ShardsComponent : IComponent { public int Value; }
}