using Code.Infrastructure.States.Infrastructure;
using VContainer;

namespace Code.Infrastructure.States.Resolvers
{
  class StateResolver : IStateResolver
  {
    private readonly IObjectResolver _resolver;

    public StateResolver(IObjectResolver resolver)
    {
      _resolver = resolver;
    }
    
    public TState Resolve<TState>() where TState : class, IState => _resolver.Resolve<TState>();
  }
}