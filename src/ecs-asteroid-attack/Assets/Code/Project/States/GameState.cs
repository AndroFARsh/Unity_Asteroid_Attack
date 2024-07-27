using Code.Common.Curtains;
using Code.Game;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.Systems;
using Code.Levels.Configs;
using Cysharp.Threading.Tasks;

namespace Code.Project.States
{
  public class GameState : EndOfFramePayloadState<LevelConfig>
  {
    private readonly GameContext _game;
    private readonly ISystemFactory _systemFactory;
    private readonly ICurtainService _curtainService;

    private GameFeature _feature;

    public GameState(GameContext game, ISystemFactory systemFactory, ICurtainService curtainService)
    {
      _game = game;
      _systemFactory = systemFactory;
      _curtainService = curtainService;
    }

    protected override void OnEnter(LevelConfig config)
    {
      _feature = _systemFactory.Create<GameFeature>(config);
      _feature.Initialize();
      
      _curtainService.Hide().Forget();
    }

    protected override void OnTick()
    {
      _feature.Execute();
      _feature.Cleanup();
    }

    protected override async UniTask OnExitAsync()
    {
      await _curtainService.Show();
      
      _feature.DeactivateReactiveSystems();
      _feature.ClearReactiveSystems();

      MarkAllEntitiesReadyToDestroy();

      _feature.Cleanup();
      _feature.TearDown();
      _feature = null;
    }

    private void MarkAllEntitiesReadyToDestroy()
    {
      foreach (GameEntity entity in _game.GetEntities())
        entity.isReadyToDestroy = true;
    }
  }
}