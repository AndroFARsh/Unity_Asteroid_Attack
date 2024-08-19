using Code.Game.Explosions.Behaviours;
using Entitas;

namespace Code.Game.Explosions
{
  [Game] public class ExplosionComponent : IComponent { }
  
  [Game] public class ExplosionAnimatorComponent : IComponent { public ExplosionAnimator Value; }
  
  [Game] public class ExplosionRunComponent : IComponent { }
}