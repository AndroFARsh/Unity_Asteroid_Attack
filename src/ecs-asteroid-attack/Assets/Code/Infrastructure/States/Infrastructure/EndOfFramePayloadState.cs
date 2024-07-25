using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.Infrastructure
{
  public abstract class EndOfFramePayloadState<TPayload> : IPayloadState<TPayload>, ITickableState {
    private UniTaskCompletionSource _completionSource;
    
    protected abstract void OnEnter(TPayload payload);

    protected virtual void OnTick()
    {
      // no-op
    }
    
    protected virtual void OnExit()
    {
      // no-op
    }

    protected virtual UniTask OnExitAsync()
    {
      OnExit();
      return UniTask.CompletedTask;
    }
    
    async UniTask IState.Exit()
    {
      _completionSource = new UniTaskCompletionSource();
      
      await _completionSource.Task;
      await OnExitAsync();
    }

    void ITickableState.Tick()
    {
      if (_completionSource == null)
        OnTick();
      
      _completionSource?.TrySetResult();
    }

    void IPayloadState<TPayload>.Enter(TPayload payload) => OnEnter(payload);
  }
}