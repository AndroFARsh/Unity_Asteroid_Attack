using System;
using Entitas;
using UnityEngine;

namespace Code.Common.View.Registrars
{
  public abstract class EntityComponentRegistrar<TEntity> : MonoBehaviour, IEntityComponentRegistrar
    where TEntity : class, IEntity
  {
    public abstract void Register(TEntity entity);

    public abstract void Unregister(TEntity entity);
    void IEntityComponentRegistrar.Register(IEntity entity)
    {
      if (entity is TEntity tEntity)
        Register(tEntity);
      else
        throw new Exception(
          $"Entity type {entity.GetType()} and Registrar supported entity type {typeof(TEntity)} not matched for {GetType()}");
    }

    void IEntityComponentRegistrar.Unregister(IEntity entity)
    {
      if (entity is TEntity tEntity)
        Unregister(tEntity);
      else
        throw new Exception(
          $"Entity type {entity.GetType()} and Registrar supported entity type {typeof(TEntity)} not matched for {GetType()}");
    }
  }
}