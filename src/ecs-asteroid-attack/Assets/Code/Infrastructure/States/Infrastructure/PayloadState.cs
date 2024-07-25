using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.Infrastructure
{
  public abstract class PayloadState<TPayload> : IPayloadState<TPayload>
  {
    protected abstract void OnEnter(TPayload payload);

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

    void IPayloadState<TPayload>.Enter(TPayload payload) => OnEnter(payload);
  }
}