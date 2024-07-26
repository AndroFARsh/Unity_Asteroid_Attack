using Code.Common.Curtains;
using Code.Infrastructure.States.Infrastructure;
using Cysharp.Threading.Tasks;

namespace Code.Project.States
{
  public class LevelsState : NoPayloadState
  {
    private readonly MetaContext _meta;
    private readonly ICurtainService _curtainService;

    public LevelsState(ICurtainService curtainService)
    {
      _curtainService = curtainService;
    }

    protected override void OnEnter()
    {
      _curtainService.Hide().Forget();
    }

    protected override async UniTask OnExitAsync()
    {
      await _curtainService.Show();
    }
  }
}