using Code.Common.View.Registrars;
using Code.Game.Player.Behaviours;
using UnityEngine;

namespace Code.Game.Player.Registrars
{
  public class CombustionAnimatorRegistrar : EntityComponentRegistrar<GameEntity>
  {
    [SerializeField] private CombustionAnimator _animator;

    public override void Register(GameEntity entity)
    {
      if (_animator == null) _animator = GetComponent<CombustionAnimator>();
      if (_animator != null) entity.AddCombustionAnimator(_animator);
    }

    public override void Unregister(GameEntity entity)
    {
      if (entity.hasCombustionAnimator)
        entity.RemoveCombustionAnimator();
    }
  }
}