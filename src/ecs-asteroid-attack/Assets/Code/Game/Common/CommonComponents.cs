using Entitas;
using UnityEngine;

namespace Code.Game.Common
{
  [Game] public class WorldPositionComponent : IComponent { public Vector2 Value; }
  
  [Game] public class ForceComponent : IComponent { public Vector2 Value; }
  
  [Game] public class TorqueComponent : IComponent { public float Value; }
  
  [Game] public class TransformComponent : IComponent { public Transform Value; }
  
  [Game] public class Collider2DComponent : IComponent { public Collider2D Value; }
  
  [Game] public class Rigidbody2DComponent : IComponent { public Rigidbody2D Value; }
  
  [Game] public class SpriteRendererComponent : IComponent { public SpriteRenderer Value; }
  
  [Game] public class LayerMaskComponent : IComponent { public int Value; }
  
  [Game] public class CollideRadiusComponent : IComponent { public float Value; }
  
}