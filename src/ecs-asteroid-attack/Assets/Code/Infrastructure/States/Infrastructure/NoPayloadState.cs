using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.Infrastructure
{
  public abstract class NoPayloadState : INoPayloadState
  {
    protected abstract void OnEnter();

    protected virtual void OnExit()
    {
      // no-op
    }
    
    protected virtual UniTask OnExitAsync()
    {
      OnExit();
      return UniTask.CompletedTask;
    }

    UniTask IState.Exit() => OnExitAsync();

    void INoPayloadState.Enter() => OnEnter();
  }
}