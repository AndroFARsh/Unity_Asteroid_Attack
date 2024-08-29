using Entitas;

namespace Code.Game.Level
{
  [Game] public class LevelComponent : IComponent { }
  [Game] public class PauseComponent : IComponent { }
  [Game] public class PauseWindowComponent : IComponent { }
  [Game] public class MenuButtonPressedComponent : IComponent { }
  [Game] public class GameOverComponent : IComponent { }
  [Game] public class WinComponent : IComponent { }
  [Game] public class NextLevelComponent : IComponent { }
  [Game] public class RouteComponent : IComponent { public RouteName Value; }
  [Game] public class MaxScoreComponent : IComponent { public int Value; }
  [Game] public class PreviousScoreComponent : IComponent { public int Value; }
  [Game] public class CurrentScoreComponent : IComponent { public int Value; }
  [Game] public class PlayerCurrentLiveComponent : IComponent { public int Value; }
  [Game] public class PlayerTotalLiveComponent : IComponent { public int Value; }
}