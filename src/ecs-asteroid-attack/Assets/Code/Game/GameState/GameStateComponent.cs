using Entitas;

namespace Code.Game.GameState
{
  [Game] public class GameStateComponent : IComponent { }
  
  [Game] public class GameOverComponent : IComponent { }
  
  [Game] public class PreviousScoreComponent : IComponent { public int Value; }
  
  [Game] public class CurrentScoreComponent : IComponent { public int Value; }
  
  [Game] public class PlayerCurrentLiveComponent : IComponent { public int Value; }
  
  [Game] public class PlayerTotalLiveComponent : IComponent { public int Value; }
}