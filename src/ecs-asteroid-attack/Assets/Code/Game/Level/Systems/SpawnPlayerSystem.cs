using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Game.Abilities;
using Code.Game.Abilities.Factories;
using Code.Game.Player.Factories;
using Code.Levels.Services;
using Entitas;

namespace Code.Game.Level.Systems
{
  public class SpawnPlayerSystem : IExecuteSystem
  {
    private readonly IPlayerFactory _playerFactory;
    private readonly IAbilityFactory _abilityFactory;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly List<GameEntity> _buffer = new(1);

    private readonly IGroup<GameEntity> _spawnEntities;
    private readonly IGroup<GameEntity> _playerEntities;

    public SpawnPlayerSystem(GameContext game,
      IPlayerFactory playerFactory,
      IAbilityFactory abilityFactory,
      ILevelDataProvider levelDataProvider)
    {
      _playerFactory = playerFactory;
      _abilityFactory = abilityFactory;
      _levelDataProvider = levelDataProvider;
      _playerEntities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
      _spawnEntities = game.GetGroup(
        GameMatcher.AllOf(
            GameMatcher.Level,
            GameMatcher.PlayerCurrentLive)
          .NoneOf(GameMatcher.GameOver));
    }

    public void Execute()
    {
      if (_playerEntities.IsNotEmpty()) return;

      foreach (GameEntity entity in _spawnEntities.GetEntities(_buffer))
      {
        entity.ReplacePlayerCurrentLive(entity.PlayerCurrentLive - 1);
        if (entity.PlayerCurrentLive > 0)
          SpawnPlayer();
        else
          entity.isGameOver = true;
      }
    }

    private void SpawnPlayer()
    {
      GameEntity player = _playerFactory.CreatePlayer(_levelDataProvider.PlayerSpawnPoint);
      _abilityFactory.CreateAbility(AbilityName.Projectile, player.Id);
    }
  }
}