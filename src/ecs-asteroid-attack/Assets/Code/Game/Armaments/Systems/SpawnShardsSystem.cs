using Code.Game.Hostiles.Factories;
using Entitas;
using UnityEngine;

namespace Code.Game.Armaments.Systems
{
  public class SpawnShardsSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly IHostileFactory _explosionFactory;

    public SpawnShardsSystem(GameContext game, IHostileFactory explosionFactory)
    {
      _explosionFactory = explosionFactory;
      _entities = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.ReadyToCleanUp,
          GameMatcher.HostileName,
          GameMatcher.Collider2D,
          GameMatcher.Shards));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        Vector2 position = entity.Rigidbody2D.position;
        float offset = Mathf.Max(entity.Collider2D.bounds.size.x, entity.Collider2D.bounds.size.y) / 2;
        for( int i = 0; i < entity.Shards; ++i)
        {
          float phase = (2 * Mathf.PI * i) / entity.Shards;
          
          Vector2 shardDirection = new(Mathf.Cos(phase) * offset, Mathf.Sin(phase) * offset);
          Vector2 shardAt = position + shardDirection;

          _explosionFactory.CreateHostileShard(entity.HostileName, shardAt, shardDirection.normalized);
        }
      }
    }
  }
}