using Code.Common.View.Registrars;
using Code.Game.Player.Behaviours;
using UnityEngine;

namespace Code.Game.Player.Registrars
{
  public class ProjectileSpawnerRegistrar : EntityComponentRegistrar<GameEntity>
  {
    [SerializeField] private ProjectileSpawner _spawner;

    public override void Register(GameEntity entity)
    {
      if (_spawner == null) _spawner = GetComponent<ProjectileSpawner>();
      if (_spawner != null) entity.AddProjectileSpawner(_spawner);
    }

    public override void Unregister(GameEntity entity)
    {
      if (entity.hasProjectileSpawner)
        entity.RemoveProjectileSpawner();
    }
  }
}