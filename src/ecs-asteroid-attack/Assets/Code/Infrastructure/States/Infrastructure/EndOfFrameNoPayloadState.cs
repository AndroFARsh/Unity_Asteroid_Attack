using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.Infrastructure
{
  public abstract class EndOfFrameNoPayloadState : INoPayloadState, ITickableState {
    private UniTaskCompletionSource _completionSource;
    
    protected abstract void OnEnter();

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
      
      _completionSource = null;
    }

    void ITickableState.Tick()
    {
      if (_completionSource == null)
        OnTick();
      
      _completionSource?.TrySetResult();
    }

    void INoPayloadState.Enter() => OnEnter();
  }
}