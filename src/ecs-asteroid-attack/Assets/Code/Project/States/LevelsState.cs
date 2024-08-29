using Code.Common.Curtains;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.Systems;
using Code.Levels;
using Cysharp.Threading.Tasks;

namespace Code.Project.States
{
  public class LevelsState : EndOfFrameNoPayloadState
  {
    private readonly MetaContext _meta;
    private readonly ISystemFactory _systemFactory;
    private readonly ICurtainService _curtainService;
    
    private LevelsFeature _feature;

    public LevelsState(MetaContext meta, ISystemFactory systemFactory, ICurtainService curtainService)
    {
      _meta = meta;
      _systemFactory = systemFactory;
      _curtainService = curtainService;
    }
    
    protected override void OnEnter()
    {
      _feature = _systemFactory.Create<LevelsFeature>();
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
      foreach (MetaEntity entity in _meta.GetEntities())
        entity.isReadyToCleanUp = true;
    }
  }
}