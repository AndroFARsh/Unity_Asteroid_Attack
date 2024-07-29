using Entitas;

namespace Code.Game.Player
{
  [Game] public class PlayerSpawnerComponent : IComponent { }
  
  [Game] public class PlayerCurrentLiveComponent : IComponent { public int Value; }
  
  [Game] public class PlayerTotalLiveComponent : IComponent { public int Value; }
  
  [Game] public class PlayerComponent : IComponent { }
}