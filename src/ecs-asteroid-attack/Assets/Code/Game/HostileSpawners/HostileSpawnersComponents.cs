using Entitas;

namespace Code.Game.HostileSpawners
{
  [Game] public class HostileSpawnerComponent : IComponent { }
  
  [Game] public class HostileSpawnerWaveComponent : IComponent { public int Value; }
  
  [Game] public class HostileSpawnedPerWaveComponent : IComponent { public int Value; }
  
  [Game] public class HostileSpawnedTotalComponent : IComponent { public int Value; }
  
  [Game] public class HostileSpawnerReadyMoveToNextWaveComponent : IComponent { }
}