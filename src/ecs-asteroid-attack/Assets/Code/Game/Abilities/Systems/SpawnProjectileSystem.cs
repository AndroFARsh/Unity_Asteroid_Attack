using System.Collections.Generic;
using Code.Game.Armaments.Factories;
using Code.Game.Player.Behaviours;
using Code.Infrastructure.Sounds;
using Entitas;

namespace Code.Game.Abilities.Systems
{
  public class SpawnProjectileSystem : IExecuteSystem
  {
    private readonly List<GameEntity> _buffer = new(5);
    private readonly IArmamentFactory _armamentFactory;
    private readonly ISoundService _soundService;
    private readonly GameContext _game;
    
    private readonly IGroup<InputEntity> _inputs;
    private readonly IGroup<GameEntity> _abilities;
    
    public SpawnProjectileSystem(GameContext game, InputContext input, IArmamentFactory armamentFactory, ISoundService soundService)
    {
      _game = game;
      _armamentFactory = armamentFactory;
      _soundService = soundService;
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
          
          _soundService.PlayFx(FxName.ShipShoot);
          _armamentFactory.CreateProjectile(spawner.Position, spawner.Direction)
            .AddOwnerId(ability.OwnerId);
        }
      }
    }
  }
}