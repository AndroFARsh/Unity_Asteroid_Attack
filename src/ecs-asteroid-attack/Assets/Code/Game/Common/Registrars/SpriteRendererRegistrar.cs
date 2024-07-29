using Code.Common.View.Registrars;
using UnityEngine;

namespace Code.Game.Common.Registrars
{
  public class SpriteRendererRegistrar : EntityComponentRegistrar<GameEntity>
  {
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public override void Register(GameEntity entity)
    {
      if (_spriteRenderer == null) _spriteRenderer = GetComponent<SpriteRenderer>();
      if (_spriteRenderer != null) entity.AddSpriteRenderer(_spriteRenderer);
    }

    public override void Unregister(GameEntity entity)
    {
      if (entity.hasSpriteRenderer)
        entity.RemoveSpriteRenderer();
    }
  }
}