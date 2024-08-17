using System.Collections.Generic;
using Code.Game.Armaments.Factories;
using Code.Game.Player.Behaviours;
using Entitas;

namespace Code.Game.Abilities.Systems
{
  public class SpawnProjectileSystem : IExecuteSystem
  {
    private readonly List<GameEntity> _buffer = new(5);
    private readonly IArmamentFactory _armamentFactory;
    private readonly GameContext _game;
    
    private readonly IGroup<InputEntity> _inputs;
    private readonly IGroup<GameEntity> _abilities;
    
    public SpawnProjectileSystem(GameContext game, InputContext input, IArmamentFactory armamentFactory)
    {
      _game = game;
      _armamentFactory = armamentFactory;
      _inputs = input.GetGroup(InputMatcher.Fire);
      _abilities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ProjectileAbility, 
          GameMatcher.AbilityName,
          GameMatcher.OwnerId,
          GameMatcher.CooldownTime,
          GameMatcher.CooldownUp));
    }

    public void Execute()
    {
      foreach (InputEntity _ in _inputs)
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
      {
        ability.isCooldownUp = false;
        ability.ReplaceCooldownLeft(ability.CooldownTime);

        GameEntity player = _game.GetEntityWithId(ability.OwnerId);
        if (player is { hasProjectileSpawner: true })
        {
          ProjectileSpawner spawner = player.ProjectileSpawner;
          _armamentFactory.CreateProjectile(spawner.Position, spawner.Direction)
            .AddOwnerId(ability.OwnerId);
        }
      }
    }
  }
}