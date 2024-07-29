using Code.Common.View.Registrars;
using UnityEngine;

namespace Code.Game.Common.Registrars
{
  public class TransformRegistrar : EntityComponentRegistrar<GameEntity>
  {
    [SerializeField] private Transform _transform;

    public override void Register(GameEntity entity)
    {
      if (_transform == null) _transform = transform;
      if (_transform != null) entity.AddTransform(_transform);
    }

    public override void Unregister(GameEntity entity)
    {
      if (entity.hasTransform)
        entity.RemoveTransform();
    }
  }
}