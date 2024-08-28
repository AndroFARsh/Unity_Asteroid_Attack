using Code.Infrastructure.Sounds;
using Entitas;

namespace Code.Game.Destroy.Systems
{
  public class PlayShipExplosionSoundEffectSystem : IExecuteSystem
  {
    private readonly ISoundService _soundService;
    private readonly IGroup<GameEntity> _entities;

    public PlayShipExplosionSoundEffectSystem(GameContext game, ISoundService soundService)
    {
      _soundService = soundService;
      _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.ReadyToCleanUp, GameMatcher.Player));
    }

    public void Execute()
    {
      foreach (GameEntity _ in _entities)
        _soundService.PlayEffect(FxName.ShipExplode);
    }
  }
}