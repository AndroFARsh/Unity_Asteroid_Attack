using Entitas;

namespace Code.Game.HostileSpawners
{
  [Game] public class HostileSpawnerComponent : IComponent { }
  
  [Game] public class HostileSpawnerWaveComponent : IComponent { public int Value; }
  
  [Game] public class HostileSpawnedPerWaveComponent : IComponent { public int Value; }
  
  [Game] public class HostileSpawnedTotalComponent : IComponent { public int Value; }
  
  [Game] public class HostileSpawnerReadyComponent : IComponent { }
  
  [Game] public class HostileSpawnerReadyMoveToNextWaveComponent : IComponent { }
  
  [Game] public class HostileSpawnerCooldownComponent : IComponent { public float Value; }
  
  [Game] public class HostileSpawnerTimerComponent : IComponent { public float Value; }
}