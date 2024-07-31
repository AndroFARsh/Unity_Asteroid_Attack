using Entitas;
using UnityEngine;

namespace Code.Game.Movement
{
  [Game] public class MovableComponent : IComponent { }
  
  [Game] public class MovingComponent : IComponent { }
  
  [Game] public class MoveDirectionComponent : IComponent { public Vector2 Value; }
  
  [Game] public class MoveVelocityComponent : IComponent { public float Value; }
  
  [Game] public class MoveAccelerationComponent : IComponent { public float Value; }
  
  [Game] public class MaxMoveSpeedComponent : IComponent { public float Value; }
  
  [Game] public class RotatableComponent : IComponent { }
  
  [Game] public class RotateAlongDirectionComponent : IComponent { }
  
  [Game] public class RotatingComponent : IComponent { }
  
  [Game] public class RotateDirectionComponent : IComponent { public float Value; }
  
  [Game] public class RotationSpeedComponent : IComponent { public float Value; }
}