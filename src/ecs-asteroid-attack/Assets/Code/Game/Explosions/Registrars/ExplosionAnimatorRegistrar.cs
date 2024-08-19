using Code.Common.View.Registrars;
using Code.Game.Explosions.Behaviours;
using UnityEngine;

namespace Code.Game.Explosions.Registrars
{
  public class ExplosionAnimatorRegistrar : EntityComponentRegistrar<GameEntity>
  {
    [SerializeField] private ExplosionAnimator _animator;

    public override void Register(GameEntity entity)
    {
      if (_animator == null) _animator = GetComponent<ExplosionAnimator>();
      if (_animator != null) entity.AddExplosionAnimator(_animator);
    }

    public override void Unregister(GameEntity entity)
    {
      if (entity.hasExplosionAnimator)
        entity.RemoveExplosionAnimator();
    }
  }
}