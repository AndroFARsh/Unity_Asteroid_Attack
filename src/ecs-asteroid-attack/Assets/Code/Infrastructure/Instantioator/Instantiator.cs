using System;
using VContainer;

namespace Code.Infrastructure.Instantioator
{
  public class Instantiator : IInstantiator
  {
    private readonly IObjectResolver _resolver;

    public Instantiator(IObjectResolver resolver)
    {
      _resolver = resolver;
    }

    public T Instantiate<T>(params object[] args) => (T)Instantiate(typeof(T), args);
    
    public object Instantiate(Type concreteType, params object[] args) {
      RegistrationBuilder registrationBuilder = new(concreteType, Lifetime.Transient);
      if (args is { Length: > 0 })
      {
        foreach (object arg in args)
          registrationBuilder.WithParameter(arg.GetType(), arg);
      }

      Registration registration = registrationBuilder.Build();
      object instance = registration.SpawnInstance(_resolver);
      return instance;
    }
  }
}