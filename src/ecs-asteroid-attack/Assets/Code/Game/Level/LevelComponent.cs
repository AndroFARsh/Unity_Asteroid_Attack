using Entitas;

namespace Code.Game.Level
{
  [Game] public class LevelComponent : IComponent { }
  
  [Game] public class GameOverComponent : IComponent { }
  
  [Game] public class GameOverWindowShownComponent : IComponent { }
 
  [Game] public class WinComponent : IComponent { }
  
  [Game] public class WinWindowShownComponent : IComponent { }
  
  [Game] public class PreviousScoreComponent : IComponent { public int Value; }
  
  [Game] public class CurrentScoreComponent : IComponent { public int Value; }
  
  [Game] public class PlayerCurrentLiveComponent : IComponent { public int Value; }
  
  [Game] public class PlayerTotalLiveComponent : IComponent { public int Value; }
}