using Code.Game.Player.Behaviours;
using Code.Game.Player.Configs;
using Entitas;
using UnityEngine;

namespace Code.Game.Player
{
  [Game] public class PlayerSpawnerComponent : IComponent { }
  
  [Game] public class VelocityComponent : IComponent { public Vector2 Value; }
  
  [Game] public class AngularVelocityComponent : IComponent { public float Value; }
  
  [Game] public class PlayerConfigComponent : IComponent { public PlayerConfig Value; }
  
  [Game] public class PlayerCurrentLiveComponent : IComponent { public int Value; }
  
  [Game] public class PlayerTotalLiveComponent : IComponent { public int Value; }
  
  [Game] public class CombustionAnimatorComponent : IComponent { public CombustionAnimator Value; }
  
  [Game] public class PlayerComponent : IComponent { }
  
  [Game] public class ProjectileSpawnerComponent : IComponent { public ProjectileSpawner Value; }
}