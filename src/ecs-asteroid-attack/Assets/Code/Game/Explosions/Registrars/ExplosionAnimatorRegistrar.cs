using Code.Common.View.Registrars;
using Code.Game.Common.Behaviours;
using UnityEngine;

namespace Code.Game.Common.Registrars
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