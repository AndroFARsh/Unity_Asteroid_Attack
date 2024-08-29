using Code.Common.Curtains;
using Code.Game;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.Systems;
using Cysharp.Threading.Tasks;
using Entitas;

namespace Code.Project.States
{
  public class GameState : EndOfFrameNoPayloadState
  {
    private readonly InputContext _input;
    private readonly GameContext _game;
    private readonly ISystemFactory _systemFactory;
    private readonly ICurtainService _curtainService;

    private GameplayFeature _feature;

    public GameState(
      InputContext input,
      GameContext game,
      ISystemFactory systemFactory, 
      ICurtainService curtainService)
    {
      _input = input;
      _game = game;
      _systemFactory = systemFactory;
      _curtainService = curtainService;
    }

    protected override void OnEnter()
    {
      _feature = _systemFactory.Create<GameplayFeature>();
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
      
      _feature.TearDown();
      _feature = null;
    }

    private void MarkAllEntitiesReadyToDestroy()
    {
      foreach (InputEntity entity in _input.GetEntities())
        entity.isReadyToCleanUp = true;
      
      foreach (GameEntity entity in _game.GetEntities())
        entity.isReadyToCleanUp = true;
    }
  }
}