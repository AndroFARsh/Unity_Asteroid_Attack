using System;

namespace Code.Infrastructure.Instantioator
{
  public interface IInstantiator
  {
    T Instantiate<T>(params object[] args);
    object Instantiate(Type concreteType, params object[] args);
  }
}